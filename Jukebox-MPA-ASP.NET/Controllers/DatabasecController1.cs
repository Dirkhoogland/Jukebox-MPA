using Jukebox_MPA_ASP.NET.Models;
using Jukebox_MPA_ASP.NET.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Diagnostics;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;


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
        
        // user related functions
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
        public void createuser(string name)
        {
           List<Users> namecheck = _context.Users.Where(m => m.Id >= 0).ToList();

            foreach(var users in namecheck)
            {
                if(users.Name == name)
                {
                    name = "duplicate";
                }
                else { }
            }

            if (name == "duplicate")
            {

            }
            else
            {
                _context.Users.Add(new Models.Database.Users() { Name = name });
                _context.SaveChanges();
            }
        }
        //----------------------------------------------------
        //playlist related functions





        //------------------------------------------
        //get functions
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
