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
    
    public class SessionController : Controller
    {
        public SessionController(ILogger<HomeController> logger)
        {
            
        }
        public static string GetQueuelistpublic()
        {
            var QueueListSession = HttpContext.Session.GetString("QueueListsession");

            return (QueueListSession);
        }
    }
}
