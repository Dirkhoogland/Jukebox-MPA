using Jukebox_MPA_ASP.NET.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace Jukebox_MPA_ASP.NET.Controllers
{
// test
    public partial class Usercontroller : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        private readonly HomeController homeController;
        public Usercontroller(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
            homeController = new HomeController(_logger, _context);
        }
        
        public string user { get; set; }
        // saves user name in session when logged out
        [HttpPost]
        public string Login([FromBody] int Id)
        {
            List<Users> currentuser;
             currentuser = _context.Users.Where(m => m.Id == Id).ToList();
            user = currentuser[0].Name;
             HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));

            return JsonConvert.SerializeObject(user);
            
        }
        // clears session upon new log in
        [HttpPost]
        public string reLogin([FromBody] int Id)
        {
            HttpContext.Session.Clear();
            List<Users> currentuser;
            currentuser = _context.Users.Where(m => m.Id == Id).ToList();
            user = currentuser[0].Name;
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
            return JsonConvert.SerializeObject(user);

        }
        // creates new user in database controller
        [HttpPost]
        public string Newuser([FromBody] string NameI)
        {
            List<Users> namecheck = _context.Users.Where(m => m.Id >= 0).ToList();

            foreach (var users in namecheck)
            {
                if (users.Name == NameI)
                {
                    NameI = "duplicate";
                }
                else { }
            }

            if (NameI == "duplicate")
            {

            }
            else
            {
                _context.Users.Add(new Models.Database.Users() { Name = NameI });
                _context.SaveChanges();
            }
            return NameI;

        }
        // deletes user from database by Id
        [HttpPost]
        public int Delete([FromBody] int Id)
        {
            List<Users> removefunct = _context.Users.Where(a => a.Id == Id).ToList();
            _context.Users.Remove(removefunct[0]);
            _context.SaveChanges();
            return Id;

        }
    }


}
