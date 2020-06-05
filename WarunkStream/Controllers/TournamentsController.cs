using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WarunkStream.Models;

namespace WarunkStream.Controllers
{
    public class TournamentsController : Controller
    {
        // GET: Tournaments
        public ActionResult Index()
        {
            var pubg = new Models.Event()
            {
                Categories = Models.Categories.PUBGM,
                TitleEvent = "TURNAMEN PUBG MOBILE - AIROKES SEASON 1"
            };
            var ml = new Models.Event()
            {
                Categories = Models.Categories.ML,
                TitleEvent = "TURNAMEN MOBILE LEGENDS - WKS PROJECT SEASON 7"
            };
            var listEvents = new List<Models.Event>();
            listEvents.Add(ml);
            listEvents.Add(pubg);
            return View(listEvents);
        }
        public async Task<ActionResult> Detail()
        {
            return View();
        }
    }
}