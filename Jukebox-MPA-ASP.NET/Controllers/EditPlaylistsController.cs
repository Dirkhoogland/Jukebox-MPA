using Jukebox_MPA_ASP.NET.Models.Database;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Runtime.CompilerServices;
using System;
using System.Xml.Linq;

namespace Jukebox_MPA_ASP.NET.Controllers
{

    public partial class EditPlaylistsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        private readonly HomeController homeController;
        
        public List<Songs> queueList { get; set; }
        
        public EditPlaylistsController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
            homeController = new HomeController(_logger, _context);
            queueList = new List<Songs>();
            
        }
        List<Songs> testplaylist;
        

        // updates local playlist by getting it from the session, then checking and adding the new song into the list before setting it again
        [HttpPost]
        public void UpdateLocalPlaylist([FromBody] int Id)
        {
            List<Songs> dbsong;
            List<Songs> oldlist;

            oldlist = null;
            
            var queueliststring = HttpContext.Session.GetString("QueueListsession");
            if (queueliststring == null)
            {

            }
            else
            {
                var newsong = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);

                 oldlist = newsong;
            }
            if (oldlist != null)
            {
                foreach (var song in oldlist)
                {
                    queueList.Add(song);
                }
            }
            dbsong = _context.Songs.Where(i => i.Id == Id).ToList();
            queueList.AddRange(dbsong);

            
            HttpContext.Session.SetString("QueueListsession", JsonConvert.SerializeObject(queueList));
            Debug.WriteLine(HttpContext.Session.GetString("QueueListsession"));
            testplaylist = queueList;


        }
        // updates playlist with userinput, gets the name + id from front end and back end db, updates it afterwards
        [HttpPost]
        public int Updatename([FromBody] Datalist Data)
        {
            int Id = Data.Id;
            string Name = Data.Name;

            List<Playlistname> updatedlist = _context.Playlistname.Where(a => a.Id == Id).ToList();
            updatedlist[0].Playlistname1 = Name;
            _context.Playlistname.Update(updatedlist[0]);
            _context.SaveChanges();

            return Id;
        }
        // fills the local playlist and sets the string with old and new songs 
        public List<Songs> FillLocalPlaylist(List<Songs> emptylist,string playlist)
        {

            if (playlist == null)
            {

                return (emptylist);
            }
            else
            {
                
                emptylist = JsonConvert.DeserializeObject<List<Songs>>(playlist);
                emptylist.ToList();
                return (emptylist);
            }

        }
        // uploads local playlist to database by sending the playlist name and retrieving songs out of session 
        [HttpPost]
        public void UploadLocalPlaylist([FromBody] string playlistname)
        {
            var userdes = HttpContext.Session.GetString("User");
            string user = (string)JsonConvert.DeserializeObject(userdes);
            var queueliststring = HttpContext.Session.GetString("QueueListsession");
            List<Songs> list = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);
            
            _context.Playlistname.Add(new Models.Database.Playlistname() { Playlistname1 = playlistname, User = user });
            _context.SaveChanges();
            List<Playlistname> name = _context.Playlistname.Where(a => a.Playlistname1 == playlistname).ToList();
            foreach (var item in list)
            {
                _context.Playlists.Add(new Models.Database.Playlists() { Song = item.Name, User = user, Playlist = name[0].Id });
                _context.SaveChanges();
            }
        }
        // calculates duration of local playlist
        public int duration(List<Songs> playlist)
        {
            int Newtotal = 0;


            List<Songs> list = playlist;
            foreach (var duration in list)
            {
                Newtotal = (int)(Newtotal + duration.Duration);
            }
            return Newtotal;
        }
        // deletes song from db playlist with Id sent from front-end
        [HttpPost]
        public int Deletesongfromplaylist([FromBody] int Id)
        {
            List<Playlists> removefunct = _context.Playlists.Where(a => a.Id == Id).ToList();
            _context.Playlists.Remove(removefunct[0]);
            _context.SaveChanges();
            return Id;
        }
        // removes from local playlist by index number in localplaylist
        [HttpPost]
        public int deletefromLocalPlaylist([FromBody] int i)
        {
            var queueliststring = HttpContext.Session.GetString("QueueListsession");
            List<Songs> list = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);
            list.RemoveAt(i);
            Debug.WriteLine(list);
            HttpContext.Session.SetString("QueueListsession", JsonConvert.SerializeObject(list));
            return i;
        }
        // finds playlist to add in song by song id and setting it in the session 
        [HttpPost]
        public int addsingleplaylist([FromBody] int Id)
        {
            List<Playlistname>  playlist = _context.Playlistname.Where(m => m.Id == Id).ToList();
            HttpContext.Session.SetString("Playlistadd", JsonConvert.SerializeObject(playlist));
            return Id;
            
        }
        // adds song into existing playlist by selecting the playlist by name in session 
        [HttpPost]
        public int addsingle([FromBody] int Id)
        {
            List<Songs> Song = _context.Songs.Where(m => m.Id == Id).ToList();
            var userdes = HttpContext.Session.GetString("User");
            string user = (string)JsonConvert.DeserializeObject(userdes);
            var playlistsdes = HttpContext.Session.GetString("Playlistadd");
            List<Playlistname> addlist = JsonConvert.DeserializeObject<List<Playlistname>>(playlistsdes);

            

            List<Playlistname> name = _context.Playlistname.Where(a => a.Playlistname1 == addlist[0].Playlistname1).ToList();
            _context.Playlists.Add(new Models.Database.Playlists() { Song = Song[0].Name , User = user, Playlist = name[0].Id });
            _context.SaveChanges();
            return Id;

        }
        //---------------------- detail view page and details
        [HttpPost]
        //sets the genre in the session the user is looking at with genre sent from front end 
        public string Songsingenre([FromBody]string Genre)
        {
            List<Genres> Grenrespecific = _context.Genres.Where(m => m.Genre == Genre).ToList();
            Debug.WriteLine(Grenrespecific);
            HttpContext.Session.SetString("Genre", JsonConvert.SerializeObject(Grenrespecific));
            return Genre;
        }
        // shows a specific song from the genre with int send from front end 
        [HttpPost]
        public int specificsongview([FromBody] int id )
        {
            List<Songs> song = _context.Songs.Where(m => m.Id == id).ToList();

            HttpContext.Session.SetString("songview", JsonConvert.SerializeObject(song));
            return id;
        }
    }

}
