using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RSakitWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        bool AddPelaporanPenggunaanVaksin(laporanpenggunaanvaksin pelaporan);


        /*[OperationContract]
        //bool UpdatePelaporanPenggunaanVaksin(laporanpenggunaanvaksin pelaporan);


        [OperationContract]
        bool DeletePelaporanPenggunaanVaksin(string IdLaporanPeng);
        */


        [OperationContract]
        IEnumerable<Pasien> GetPasien();

        [OperationContract]
        IEnumerable<Vaksin> GetVaksin();


        [OperationContract]
        IEnumerable<Rumah_Sakit> GetRumah_Sakit();

    }
}
