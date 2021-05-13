using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdusenCRUD.Models;

namespace ProdusenCRUD.Controllers
{
    public class VaksinController : Controller
    {
        // GET: Vaksin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (TVaksinEntities2 db = new TVaksinEntities2())
            {
                List<Vaksin> vaksinList = db.Vaksin.ToList<Vaksin>();
                return Json(new { data = vaksinList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddnEdit(int id = 0)
        {
            if (id == 0)
                return View(new Vaksin());
            else
            {
                using (TVaksinEntities2 db = new TVaksinEntities2())
                {
                    return View(db.Vaksin.Where(x => x.IdVaksin == id).FirstOrDefault<Vaksin>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddnEdit(Vaksin vak)
        {
            using (TVaksinEntities2 db = new TVaksinEntities2())
            {
                if (vak.IdVaksin == 0)
                {
                    db.Vaksin.Add(vak);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(vak).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (TVaksinEntities2 db = new TVaksinEntities2())
            {
                Vaksin emp = db.Vaksin.Where(x => x.IdVaksin == id).FirstOrDefault<Vaksin>();
                db.Vaksin.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}