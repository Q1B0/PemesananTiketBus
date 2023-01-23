using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemesananTiketBus.Model.Entity
{
    // Deklarasi kelas Bus
    public class Bus
    {
        // Membuat properti yang dapat diakses di luar kelas
        public string IDBus { get; set; }
        public string Nama { get; set; }
        public string Rute { get; set; }
        public int Harga { get; set; }
    }
}
