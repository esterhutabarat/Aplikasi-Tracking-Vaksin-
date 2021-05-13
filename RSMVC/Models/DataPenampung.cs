using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSMVC.ServiceReference1;

namespace RSMVC.Models
{
    public class DataPenampung
    {
        public IEnumerable<Vaksin> AllVaksin { get; set; }
        public IEnumerable<Pasien> AllPasien { get; set; }
        public IEnumerable<Rumah_Sakit> AllRS { get; set; }
    }
}