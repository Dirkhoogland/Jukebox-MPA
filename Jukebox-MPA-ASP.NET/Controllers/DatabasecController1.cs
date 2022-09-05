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
    [BindProperties(SupportsGet = true)]
    public class DatabasecController1 : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;


        public DatabasecController1(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;

        }
        
        
        //gets user to set into session as logged in
        public List<Users> getuser(int Id)
        {           
            return _context.Users.Where(m => m.Id == Id).ToList();
        }
        //gets users for user page 
        public List<Users> getusers()
        {
            return _context.Users.Where(m => m.Id >= 0).ToList();
        }
        // gets songs for view
        public List<Songs> GetSongs()
        {
            return _context.Songs.Where(m => m.Id >= 0).ToList();
        }
        // gets genre's for view
        public List<Genres> GetGenres()
        {
            return _context.Genres.Where(m => m.Id >= 0).ToList();
        }
    }
}
