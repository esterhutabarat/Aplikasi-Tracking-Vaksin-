using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BPOM.Models;

namespace BPOM.Controllers
{
    public class VaksinListController : Controller
    {
        // GET: VaksinList
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            using (TVaksinEntities db = new TVaksinEntities())
            {
                List<Vaksin> VaksinList = db.Vaksin.ToList<Vaksin>();
                return Json(new { data = VaksinList }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}