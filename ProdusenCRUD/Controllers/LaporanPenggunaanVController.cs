using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdusenCRUD.Models;

namespace ProdusenCRUD.Controllers
{
    public class LaporanPenggunaanVController : Controller
    {
        // GET: LaporanPenggunaanV
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            using (TVaksinEntities2 db = new TVaksinEntities2())
            {
                List<laporankedatanganvaksin> laporList = db.laporankedatanganvaksin.ToList<laporankedatanganvaksin>();
                return Json(new { data = laporList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddnEdit(int id = 0)
        {
            if (id == 0)
                return View(new laporankedatanganvaksin());
            else
            {
                using (TVaksinEntities2 db = new TVaksinEntities2())
                {
                    return View(db.laporankedatanganvaksin.Where(x => x.IdLaporan == id).FirstOrDefault<laporankedatanganvaksin>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddnEdit(laporankedatanganvaksin lap)
        {
            using (TVaksinEntities2 db = new TVaksinEntities2())
            {
                if (lap.IdLaporan == 0)
                {
                    db.laporankedatanganvaksin.Add(lap);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    db.Entry(lap).State = EntityState.Modified;
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
                laporankedatanganvaksin lap = db.laporankedatanganvaksin.Where(x => x.IdLaporan == id).FirstOrDefault<laporankedatanganvaksin>();
                db.laporankedatanganvaksin.Remove(lap);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}