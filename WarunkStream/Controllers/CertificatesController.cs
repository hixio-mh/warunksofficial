using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WarunkStream.Controllers
{
    public class CertificatesController : Controller
    {
        // GET: Certificates
        public async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> Result(string id)
        {
            return View();
        }
    }
}