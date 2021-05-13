using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RSakitWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public bool AddPelaporanPenggunaanVaksin(laporanpenggunaanvaksin pelaporan)
        {
            TVaksinEntities2 vaksinEntities = new TVaksinEntities2();
            if (pelaporan != null)
            {
                vaksinEntities.laporanpenggunaanvaksin.Add(pelaporan);
                vaksinEntities.SaveChanges();
                vaksinEntities.Dispose();

                return true;
            }
            vaksinEntities.Dispose();
            return false;

        }

        public IEnumerable<Pasien> GetPasien()
        {
            TVaksinEntities2 vaksinEntities = new TVaksinEntities2();
            IEnumerable<Pasien> listPasien = vaksinEntities.Pasien.ToList();

            return listPasien;
        }

        public IEnumerable<Vaksin> GetVaksin()
        {
            TVaksinEntities2 vaksinEntities = new TVaksinEntities2();
            IEnumerable<Vaksin> listVaksin = vaksinEntities.Vaksin.ToList();

            return listVaksin;
        }

        public IEnumerable<Rumah_Sakit> GetRumah_Sakit()
        {
            TVaksinEntities2 vaksinEntities = new TVaksinEntities2();
            IEnumerable<Rumah_Sakit> listRumah_Sakit= vaksinEntities.Rumah_Sakit.ToList();

            return listRumah_Sakit;
        }
    }
}
