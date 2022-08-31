using Jukebox_MPA_ASP.NET.Models.Database;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Jukebox_MPA_ASP.NET.Controllers
{

    public partial class EditPlaylistsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        private readonly SessionController sessioncontroller;

        public HomeController homeController;
        
        public EditPlaylistsController(ILogger<HomeController> logger, DatabaseContext context) 
        {
            _logger = logger;
            _context = context;
            sessioncontroller = new SessionController(_logger, _context);


            homeController = new HomeController(_logger, _context);
            //sessions = new Sessions(_httpContextAccessor);
        }
        private List<Songs> Queuelist;
        

        [HttpPost]
        public void UpdateLocalPlaylist([FromBody] int Id)
        {
            List<Songs> dbsong;

            var queueliststring = sessioncontroller.GetQueuelistpublic();


            if (queueliststring == null) { }
            else
            {
                var newsong = JsonConvert.DeserializeObject<List<Songs>>(queueliststring);

                Queuelist = newsong;
            }
            dbsong = _context.Songs.Where(i => i.Id == Id).ToList();
            Queuelist.AddRange(dbsong);


            sessioncontroller.UpdateQueue(Queuelist);


        }

        public List<Songs> FillLocalPlaylist(List<Songs> emptylist)
        {


            var playlist = sessioncontroller.GetQueuelistpublic();
            if (playlist == null)
            {

                return (emptylist);
            }
            else
            {
                var sessionlistdes = sessioncontroller.GetQueuelistpublic();
                emptylist = JsonConvert.DeserializeObject<List<Songs>>(sessionlistdes);
                emptylist.ToList();
                return (emptylist);
            }

        }


    }
}
