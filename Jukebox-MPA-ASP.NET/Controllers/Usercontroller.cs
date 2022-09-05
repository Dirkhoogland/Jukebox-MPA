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
        [HttpPost]
        public void Login([FromBody] int Id)
        {
            List<Users> currentuser;
            
            currentuser = data.getuser(Id);
           string User = currentuser[0].Name;
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(User));
            var test = 0;
        }


    }

  
}
