using Jukebox_MPA_ASP.NET.Models;
using Jukebox_MPA_ASP.NET.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Diagnostics;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jukebox_MPA_ASP.NET.Controllers
{

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8604 // Possible null reference argument.
        [BindProperties(SupportsGet = true)]
        public class HomeController : Controller
        {



            private readonly ILogger<HomeController> _logger;
            private readonly DatabaseContext _context;
            
            
            public HomeController(ILogger<HomeController> logger, DatabaseContext context)
            {
                _logger = logger;
                _context = context;
                
            
            }
            int i = 0;

            

            public List<Songs> emptylist { get; set; }
            // view for index function, does check if session has a user and who it is before requesting all users from db model 
            public IActionResult Index()
            {

            
            var userdes = HttpContext.Session.GetString("User");
            
            if (userdes != null)
            {
                var user = JsonConvert.DeserializeObject(userdes);
                ViewBag.user = user;
            }
            else
            {
                ViewBag.user = "Login";
            }

            List<Users> Users = _context.Users.Where(m => m.Id >= 0).ToList();
            ViewBag.Users = Users;
                
                //DataSeed();
                return View();
            }
            // lists view, does same as index view but also sees if user has any lists connected to it 
            public IActionResult Lists()
            {
            var userdes = HttpContext.Session.GetString("User");
            
            if (userdes != null)
            {
                var user = JsonConvert.DeserializeObject(userdes);
                ViewBag.user = user;
                string userstring = user.ToString();
                List<Playlists> playlists = _context.Playlists.Where(m => m.User == user).ToList();
                List<Playlistname> playlistname = _context.Playlistname.Where(m => m.User == user).ToList();
                ViewBag.playlists = playlists;
                ViewBag.userjson = userdes;
                ViewBag.playlistsuser = playlistname;
                ViewBag.playlistname = playlistname[0].Playlistname1;
                ViewBag.usercheck = playlistname[0].User;


            }
            else
            {
                ViewBag.user = "Login";
            }
            // calls up the playlist controller to check list and if to fill it 
            EditPlaylistsController controller = new EditPlaylistsController(_logger, _context);
                var playlistvar = HttpContext.Session.GetString("QueueListsession");
                emptylist = controller.FillLocalPlaylist(emptylist, playlistvar);
            if (playlistvar != null)
            {
                int totalduration = controller.duration(JsonConvert.DeserializeObject<List<Songs>>(playlistvar));
                ViewBag.duration = totalduration;
            }
                ViewBag.songlist = emptylist;
                
            


                return View();
            }
            // creates genre view does same as index but checks if there are any genres in the db 
            public IActionResult Genre()
            {
            var userdes = HttpContext.Session.GetString("User");
            if (userdes != null)
            {
                var user = JsonConvert.DeserializeObject(userdes);
                ViewBag.user = user;
                
            }
            else
            {
                ViewBag.user = "Login";
            }
            List<Genres> genresf = _context.Genres.Where(m => m.Id >= 0).ToList();
            ViewBag.genre = genresf;


                return View();
            }
        // shows songs from specific genre when selected 
            public IActionResult Songs(string genre)
            {
            var userdes = HttpContext.Session.GetString("User");
            if (userdes != null)
            {
                var user = JsonConvert.DeserializeObject(userdes);
                ViewBag.user = user;

            }
            else
            {
                ViewBag.user = "Login";
            }
            // checks if updateplaylist 
            var playlistsdes = HttpContext.Session.GetString("Playlistadd");
            if (playlistsdes != null)
            {
                List<Playlistname> addlist = JsonConvert.DeserializeObject<List<Playlistname>>(playlistsdes);
                ViewBag.addlist = addlist[0].Playlistname1;
                ViewBag.Idlist = addlist[0].Id;
            }
            else
            {
                ViewBag.addlist = "Non";
            }




            var Genredes = HttpContext.Session.GetString("Genre");
            if (Genredes != null)
            {
                List<Genres> genresspecific = JsonConvert.DeserializeObject<List<Genres>>(Genredes);
                ViewBag.genre = genresspecific[0].Genre;
            }
            
            List<Songs> Items = _context.Songs.Where(m => m.Id >= 0).ToList();
            ViewBag.item = Items;




            return View();
            }
        // shows details of specific song when selected in the songs page 
        public IActionResult Songsspecific()
        {
            var playlistsdes = HttpContext.Session.GetString("Playlistadd");
            if (playlistsdes != null)
            {
                List<Playlistname> addlist = JsonConvert.DeserializeObject<List<Playlistname>>(playlistsdes);
                ViewBag.addlist = addlist[0].Playlistname1;
                ViewBag.Idlist = addlist[0].Id;
            }
            else
            {
                ViewBag.addlist = "Non";
            }
            var songviewdes = HttpContext.Session.GetString("songview");
            if (songviewdes != null)
            {
                List<Songs> Songview = JsonConvert.DeserializeObject<List<Songs>>(songviewdes);
                ViewBag.songname = Songview[0].Name;
                ViewBag.songdur = Songview[0].Duration;
                ViewBag.songid = Songview[0].Id;
                ViewBag.songAuthor = Songview[0].Author;
            }
            return View();
        }

            [ResponseCache(Duration = 1000000, Location = ResponseCacheLocation.None, NoStore = false)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // seeds database data 
        private void DataSeed()
        {
            try
            {
                _context.Genres.Add(new Models.Database.Genres() { Genre = "Pop" });
                _context.Genres.Add(new Models.Database.Genres() { Genre = "Rock" });
                _context.Genres.Add(new Models.Database.Genres() { Genre = "Metal" });
                _context.Genres.Add(new Models.Database.Genres() { Genre = "test" });
                _context.Genres.Add(new Models.Database.Genres() { Genre = "classical" });
                _context.Songs.Add(new Models.Database.Songs() { Genre = "Pop", Author = "TestAuthor", Name = "Test", Duration = 3 });
                _context.Songs.Add(new Models.Database.Songs() { Genre = "Rock", Author = "TestAuthor1", Name = "Testsong", Duration = 5 });
                _context.Songs.Add(new Models.Database.Songs() { Genre = "Metal", Author = "TestAuthor2", Name = "Testsong2", Duration = 2 });
                _context.Songs.Add(new Models.Database.Songs() { Genre = "test", Author = "TestAuthor4", Name = "Testsong21", Duration = 6 });
                _context.Songs.Add(new Models.Database.Songs() { Genre = "classical", Author = "TestAuthor5", Name = "Testsong23", Duration = 7 });
                _context.Users.Add(new Models.Database.Users() { Name = "Dirk" });
                _context.Users.Add(new Models.Database.Users() { Name = "Test1" });
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }



#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
    }
}


