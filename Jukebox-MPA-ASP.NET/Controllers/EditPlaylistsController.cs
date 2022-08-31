using Jukebox_MPA_ASP.NET.Models.Database;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Newtonsoft.Json;
using System.Diagnostics;
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

    public partial class EditPlaylistsController : Controller
    {
        private readonly DatabaseContext _context;
        public EditPlaylistsController(ILogger<HomeController> logger, DatabaseContext context) 
        { 
            _context = context;
        }

        private List<Songs> Queuelist;
        [HttpPost]
        public void UpdateLocalPlaylist([FromBody] int Id)
        {
         List<Songs> dbsong;

            var queueliststring = SessionController.GetQueuelistpublic();


            if (queueliststring == null) { }
            else
            {
                var newsong = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);
                
                Queuelist = newsong;
            }
            dbsong = _context.Songs.Where(i => i.Id == Id).ToList();
            Queuelist.AddRange(dbsong);
            HttpContext.Session.SetString("QueueListsession", JsonConvert.SerializeObject(Queuelist));
            HttpContext.Session.GetString("QueueListsession");
        }

        public static List<Songs> FillLocalPlaylist(List<Songs> emptylist)
        {
            var playlist = SessionController.GetQueuelistpublic();
            if (playlist == null)
            {
                
                return (emptylist);
            }
            else
            {
                var sessionlistdes = SessionController.GetQueuelistpublic();
                emptylist = JsonConvert.DeserializeObject<List<Songs>>(sessionlistdes);
                emptylist.ToList();
                return (emptylist);
            }




        }

    }
}
