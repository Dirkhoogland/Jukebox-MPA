using Jukebox_MPA_ASP.NET.Models.Database;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Runtime.CompilerServices;
using System;

namespace Jukebox_MPA_ASP.NET.Controllers
{

    public partial class EditPlaylistsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        private readonly HomeController homeController;
        private readonly DatabasecController1 data;
        public List<Songs> queueList { get; set; }
        
        public EditPlaylistsController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
            homeController = new HomeController(_logger, _context);
            queueList = new List<Songs>();
            data = new DatabasecController1(_logger, _context);
        }
        List<Songs> testplaylist;
        

        // updates local playlist
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
        // updates playlist with userinput
        [HttpPost]
        public int Updatename([FromBody] Datalist Data)
        {
            int Id = Data.Id;
            string Name = Data.Name;
            data.updatename(Id, Name);

            return Id;
        }
        // fills the local playlist
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
        // uploads local playlist to database
        [HttpPost]
        public void UploadLocalPlaylist([FromBody] string playlistname)
        {
            var userdes = HttpContext.Session.GetString("User");
            string user = (string)JsonConvert.DeserializeObject(userdes);
            var queueliststring = HttpContext.Session.GetString("QueueListsession");
            List<Songs> list = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);
            data.uploadlist(list, playlistname, user);
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
        // deletes song from db playlist
        [HttpPost]
        public int Deletesongfromplaylist([FromBody] int Id)
        {
            data.deletesong(Id);
            return Id;
        }
        // removes from local playlist
        [HttpPost]
        public int deletefromLocalPlaylist([FromBody] int i)
        {
            var queueliststring = HttpContext.Session.GetString("QueueListsession");
            List<Songs> list = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);
            list.RemoveAt(i);
            HttpContext.Session.SetString("QueueListsession", JsonConvert.SerializeObject(queueliststring));
            return i;
        }
        // finds playlist to add in 
        [HttpPost]
        public int addsingleplaylist([FromBody] int Id)
        {
            List<Playlistname>  playlist = data.GetPlaylistnames(Id);
            HttpContext.Session.SetString("Playlistadd", JsonConvert.SerializeObject(playlist));
            return Id;
            
        }
        // adds song into existing playlist
        [HttpPost]
        public int addsingle([FromBody] int Id)
        {
            List<Songs> Song = data.GetSong(Id);
            var userdes = HttpContext.Session.GetString("User");
            string user = (string)JsonConvert.DeserializeObject(userdes);
            var playlistsdes = HttpContext.Session.GetString("Playlistadd");
            List<Playlistname> addlist = JsonConvert.DeserializeObject<List<Playlistname>>(playlistsdes);

            data.updatelist(Song, addlist[0].Playlistname1, user);
                return Id;

        }
        //---------------------- detail view page and details
        [HttpPost]
        public string Songsingenre([FromBody]string Genre)
        {
            List<Genres> Grenrespecific = data.getGenrebyname(Genre);
            Debug.WriteLine(Grenrespecific);
            HttpContext.Session.SetString("Genre", JsonConvert.SerializeObject(Grenrespecific));
            return Genre;
        }
        [HttpPost]
        public int specificsongview([FromBody] int id )
        {
            List<Songs> song = data.GetSong(id);
            
            HttpContext.Session.SetString("songview", JsonConvert.SerializeObject(song));
            return id;
        }
    }

}
