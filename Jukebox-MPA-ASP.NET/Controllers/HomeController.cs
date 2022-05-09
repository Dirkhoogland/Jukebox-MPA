using Jukebox_MPA_ASP.NET.Models;
using Jukebox_MPA_ASP.NET.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Diagnostics;
using System.Configuration;



namespace Jukebox_MPA_ASP.NET.Controllers
{
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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Lists()
        {
            
            return View();
        }

        public IActionResult Genre()
        {
            //var item = _context.Songs.SelectMany(i => i.Id > 0);
            //var item = _context.Songs.FirstOrDefault(i => i.Id > 0);
            var item = _context.Songs.Where(s => s.Id > 0);
            ViewBag.item = item;
            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public Task Atpl(int Id, string playlist)
        //{
        //    var song = _context.Songs.FirstOrDefault(i => i.Id == Id);
        //    playlistadd = playlist;
        //    if (song == null)
        //    {

        //    }
        //    else
        //    {
        //        _context.Playlists.Add(new Playlists()
        //        {
        //            Song = song.Song,
        //            Id = song.Id,
        //            Playlist = playlistadd,



        //        });

                
        //    }
            
        }
        


    }
