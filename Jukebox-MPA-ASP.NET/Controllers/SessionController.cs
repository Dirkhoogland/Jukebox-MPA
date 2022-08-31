using Jukebox_MPA_ASP.NET.Models.Database;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace Jukebox_MPA_ASP.NET.Controllers
{

    public partial class SessionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public SessionController(ILogger<HomeController> logger, DatabaseContext context)
        {   
            _logger = logger;
            _context = context;

        }
        public void load()
        {
            string firstload = "empty";
            HttpContext.Session.SetString("QueueListsession", JsonConvert.SerializeObject(firstload));
        }

        public string GetQueuelistpublic()
        {

            var QueueListSession = HttpContext.Session.GetString("QueueListsession");




            return (QueueListSession);
        }

        public void UpdateQueue(List<Songs> Queuelist)
        {
            HttpContext.Session.SetString("QueueListsession", JsonConvert.SerializeObject(Queuelist));
        }

        //public string getlist()
        //{
        //    var QueueList = HttpContext.Session.GetString("QueueListsession");
        //    return (QueueList);
        //}
    }
}
