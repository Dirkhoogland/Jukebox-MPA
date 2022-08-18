//using Jukebox_MPA_ASP.NET.Models.Database;
//using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
//using Newtonsoft.Json;
//using System.Diagnostics;
//using Jukebox_MPA_ASP.NET.Models;
//using Jukebox_MPA_ASP.NET.Models.Database;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
//using System.Diagnostics;
//using System.Configuration;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//private readonly DatabaseContext _context;
//namespace Jukebox_MPA_ASP.NET.Controllers
//{
//    public class EditPlaylists : HomeController
//    {
//        public EditPlaylists(ILogger<HomeController> logger, DatabaseContext context) : base(logger, context)
//        {
//        }

//        public void UpdateQueue(int Id ) 
//        {



//            Debug.WriteLine(Queuelist);
//            var queueliststring = HttpContext.Session.GetString("QueueListsession");
//            //JObject json = JObject.Parse(queueliststring);

//            if (queueliststring == null) { }
//            else
//            {
//                var newsong = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);
//                //Queuelist = JsonSerializer.Deserialize<List<Songs>>(queueliststring);
//                Queuelist = newsong;
//            }
//            dbsong = _context.Songs.Where(i => i.Id == Id).ToList();
//            Queuelist.AddRange(dbsong);
//            HttpContext.Session.SetString("QueueListsession", JsonConvert.SerializeObject(Queuelist));

//            Debug.WriteLine(HttpContext.Session.GetString("QueueListsession"));


//            return View(Genre());



//        }



//    }
//}
