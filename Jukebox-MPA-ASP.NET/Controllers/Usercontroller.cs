using Jukebox_MPA_ASP.NET.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Jukebox_MPA_ASP.NET.Controllers
{

    public partial class Usercontroller : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        private readonly HomeController homeController;
        private readonly DatabasecController1 data;
        public Usercontroller(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
            homeController = new HomeController(_logger, _context);
            data = new DatabasecController1(_logger, _context); 
        }
        
        public string user { get; set; }
        // saves user name in session
        [HttpPost]
        public string Login([FromBody] int Id)
        {
            List<Users> currentuser;
             currentuser = data.getuser(Id);
             user = currentuser[0].Name;
             HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
            return JsonConvert.SerializeObject(user);
            
        }
        [HttpPost]
        public string reLogin([FromBody] int Id)
        {
            HttpContext.Session.Clear();
            List<Users> currentuser;
            currentuser = data.getuser(Id);
            user = currentuser[0].Name;
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
            return JsonConvert.SerializeObject(user);

        }
        // creates new user in database controller
        [HttpPost]
        public string Newuser([FromBody] string Name)
        {
            data.createuser(Name);
            return Name;

        }
        // deletes user
        // 
        [HttpPost]
        public int Delete([FromBody] int Id)
        {
            data.deleteuser(Id);
            return Id;

        }
    }


}
