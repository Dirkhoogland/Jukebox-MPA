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
        public string? inputName { get; set; }
        public int? Id { get; set; }

        public const string SessionKeyName = "_User";
        public const string SessionKeyId = "_Id";

        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        private List<Songs> test;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        //public int[] Idsqueue = new int[];
        public List<Songs> Items { get; set; }

        public List<Songs> Queuelist { get; set; }

        public List<Users?> Users { get; set; }
        public IActionResult Index()
        {
            


            //DataSeed();
            return View();
        }

        public IActionResult Lists()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Genre()
        {
            Items = _context.Songs.Where(m => m.Id >= 0).ToList();
            ViewBag.item = Items;

            if(Queuelist.Count >= 1)
            {
                foreach(var id in Queuelist.)
            }

            Debug.WriteLine(Queuelist);
            return View();
        }
        

        [HttpPost]
        public IActionResult addtoqueue([FromBody] int Id)
        {




            Debug.WriteLine(Queuelist);
            var queueliststring = HttpContext.Session.GetString("QueueListsession");
            //JObject json = JObject.Parse(queueliststring);
           
            if (queueliststring == null) { }
            else
            {
                var test2 = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);
                //Queuelist = JsonSerializer.Deserialize<List<Songs>>(queueliststring);
                Queuelist = test2;
            }
            test = _context.Songs.Where(i => i.Id == Id).ToList();
            Queuelist.AddRange(test);
            HttpContext.Session.SetString("QueueListsession", JsonConvert.SerializeObject(Queuelist));

            Debug.WriteLine(HttpContext.Session.GetString("QueueListsession"));

            Genre();
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


