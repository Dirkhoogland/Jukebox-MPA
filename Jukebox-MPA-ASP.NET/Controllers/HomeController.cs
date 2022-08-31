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

        public const string SessionKeyName = "_User";
        public const string SessionKeyId = "_Id";

        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        private readonly SessionController sessioncontroller;


        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
            sessioncontroller = new SessionController(_logger, _context);
        }
        int i = 0;

        public List<Users> Users { get; set; }

        public List<Songs> emptylist { get; set; }

        public void firstload(int i)
        {
            sessioncontroller.load();

            i++;
        }

        public IActionResult Index()
        {
            if(i == 0)
            {
             firstload(i);
            }



            Users = _context.Users.Where(m => m.Id >= 0).ToList();
            ViewBag.Users = Users;
            ViewBag.songlist = emptylist;
            //DataSeed();
            return View();
        }

        public IActionResult Lists()
        {

            EditPlaylistsController controller = new EditPlaylistsController(_logger, _context);
            controller.FillLocalPlaylist(emptylist);



            return View();
        }
        [HttpGet]
        public IActionResult Genre()
        {


            List<Genres> genresf = _context.Genres.Where(m => m.Id >= 0).ToList();
            List<Songs> Items = _context.Songs.Where(m => m.Id >= 0).ToList();
            ViewBag.item = Items;
            ViewBag.genre = genresf;


            return View();
        }


        //[HttpPost]
        //public IActionResult addtoqueue([FromBody] int Id)
        //{



        //    Debug.WriteLine(Queuelist);
        //    var queueliststring = HttpContext.Session.GetString("QueueListsession");
        //    //JObject json = JObject.Parse(queueliststring);

        //    if (queueliststring == null) { }
        //    else
        //    {
        //        var newsong = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);
        //        //Queuelist = JsonSerializer.Deserialize<List<Songs>>(queueliststring);
        //        Queuelist = newsong;
        //    }
        //    dbsong = _context.Songs.Where(i => i.Id == Id).ToList();
        //    Queuelist.AddRange(dbsong);
        //    HttpContext.Session.SetString("QueueListsession", JsonConvert.SerializeObject(Queuelist));

        //    Debug.WriteLine(HttpContext.Session.GetString("QueueListsession"));


        //    return View(Genre());
        //}


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


