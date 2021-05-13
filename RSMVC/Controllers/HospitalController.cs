using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSMVC.ServiceReference1;

namespace RSMVC.Controllers
{
    public class HospitalController : Controller
    {
        // GET: Hospital
        public ActionResult Index()
        {
            Service1Client service1Client = new Service1Client();
            Models.DataPenampung data = new Models.DataPenampung
            {
                AllVaksin = service1Client.GetVaksin(),
                AllPasien = service1Client.GetPasien(),
                AllRS = service1Client.GetRumah_Sakit()
            };
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(string IdLaporanPeng, string IdRSakit, string NoRegisVaksin, string NikPasien, string NoRekamMedis)
        {
            Service1Client service1Client = new Service1Client();
            ServiceReference1.laporanpenggunaanvaksin data = new ServiceReference1.laporanpenggunaanvaksin
            {
                IdLaporanPeng = IdLaporanPeng,
                IdBPOM = "BPOM",
                IdRSakit = IdRSakit,
                NoRegisVaksin = NoRegisVaksin,
                NikPasien = NikPasien,
                NoRekamMedis = NoRekamMedis
            };
            if (service1Client.AddPelaporanPenggunaanVaksin(data))
            {
                return View("success");
            }
            Models.DataPenampung ester = new Models.DataPenampung
            {
                AllVaksin = service1Client.GetVaksin(),
                AllPasien = service1Client.GetPasien(),
                AllRS = service1Client.GetRumah_Sakit()
            };
            return View(ester);
        }
    }
}