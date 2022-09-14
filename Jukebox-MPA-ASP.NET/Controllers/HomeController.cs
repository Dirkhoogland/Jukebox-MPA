﻿using Jukebox_MPA_ASP.NET.Models;
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

            public string? inputName { get; set; }
            public int? Id { get; set; }

            private readonly ILogger<HomeController> _logger;
            private readonly DatabaseContext _context;
            private readonly DatabasecController1 data;
            
            public HomeController(ILogger<HomeController> logger, DatabaseContext context)
            {
                _logger = logger;
                _context = context;
                data = new DatabasecController1(_logger, _context);
            
            }
            int i = 0;

            

            public List<Songs> emptylist { get; set; }
            
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

            List<Users> Users = data.getusers();
                ViewBag.Users = Users;
                
                //DataSeed();
                return View();
            }
            
            public IActionResult Lists()
            {
            var userdes = HttpContext.Session.GetString("User");
            
            if (userdes != null)
            {
                var user = JsonConvert.DeserializeObject(userdes);
                ViewBag.user = user;
                string userstring = user.ToString();
                List<Playlists> playlists = data.getplaylists(userstring);
                List<Playlistname> playlistname = data.getnames(userstring);
                ViewBag.playlists = playlists;
                ViewBag.userjson = userdes;
                ViewBag.playlistname = playlistname;

            }
            else
            {
                ViewBag.user = "Login";
            }
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
            List<Genres> genresf = data.GetGenres();
                List<Songs> Items = data.GetSongs();
                ViewBag.item = Items;
                ViewBag.genre = genresf;


                return View();
            }



            [ResponseCache(Duration = 1000, Location = ResponseCacheLocation.None, NoStore = false)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


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


