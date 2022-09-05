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
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Controllers
{

    public partial class EditPlaylistsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        private readonly HomeController homeController;
        public List<Songs> queueList { get; set; }

        public EditPlaylistsController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
            homeController = new HomeController(_logger, _context);
            queueList = new List<Songs>();
        }

        


    [HttpPost]
        public void UpdateLocalPlaylist([FromBody] int Id)
        {
            List<Songs> dbsong;
            
            var queueliststring = HttpContext.Session.GetString("QueueListsession");

            Debug.WriteLine(queueList);
            if (queueliststring == null) { 
            
            } else
            {
                var newsong = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);

                queueList = newsong;
            }
            dbsong = _context.Songs.Where(i => i.Id == Id).ToList();
            queueList.AddRange(dbsong);


            HttpContext.Session.SetString("QueueListsession", JsonConvert.SerializeObject(queueList));
            Debug.WriteLine(HttpContext.Session.GetString("QueueListsession"));


            

        }

        public List<Songs> FillLocalPlaylist(List<Songs> emptylist,string playlist)
        {

            if (playlist == null)
            {

                return (emptylist);
            }
            else
            {
                
                emptylist = JsonConvert.DeserializeObject<List<Songs>>(playlist);
                emptylist.ToList();
                return (emptylist);
            }

        }


    }
}
