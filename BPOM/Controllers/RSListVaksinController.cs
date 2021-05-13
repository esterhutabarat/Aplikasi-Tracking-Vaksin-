using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BPOM.Models;

namespace BPOM.Controllers
{
    public class RSListVaksinController : Controller
    {
        // GET: RSListVaksin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            using (TVaksinEntities db = new TVaksinEntities())
            {
                List<Rumah_Sakit> RSakitList = db.Rumah_Sakit.ToList<Rumah_Sakit>();
                return Json(new { data = RSakitList }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}