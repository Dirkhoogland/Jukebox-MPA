using Jukebox_MPA_ASP.NET.Models.Database;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public int Deletesongfromplaylist([FromBody] int Id)
        {
            data.deletesong(Id);
            return Id;
        }
        [HttpPost]
        public int deletefromLocalPlaylist([FromBody] int i)
        {
            var queueliststring = HttpContext.Session.GetString("QueueListsession");
            List<Songs> list = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);
            list.RemoveAt(i);
            return i;
        }
        
    }

}
