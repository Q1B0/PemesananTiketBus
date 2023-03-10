using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemesananTiketBus.Model.Entity
{
    // Deklasrasi kelas Tiket
    public class Tiket
    {
        // Membuat properti yang dapet diakses di luar kelas
        public string IDTiket { get; set; }
        public DateTime TanggalTiket { get; set; }
        public DateTime TanggalBerangkat { get; set; }
        public int JumlahTiket { get; set; }
        public string Keterangan { get; set; }
        public Bus Bus { get; set; }
        public Pelanggan Pelanggan { get; set; }
    }
}
