using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdusenCRUD.Models;

namespace ProdusenCRUD.Controllers
{
    public class ProdusenListController : Controller
    {
        // GET: ProdusenList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (TVaksinEntities2 db = new TVaksinEntities2())
            {
                List<Produsen> ProdusenList = db.Produsen.ToList<Produsen>();
                return Json(new { data = ProdusenList }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}