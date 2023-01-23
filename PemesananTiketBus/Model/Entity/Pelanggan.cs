using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemesananTiketBus.Model.Entity
{
    // Deklarasi kelas Pelanggan
    public class Pelanggan
    {
        // Membuat properti yang dapat diakses diluar kelas
        public string IdPelanggan { get; set; }
        public string Nama { get; set; }
        public string No_tlp { get; set; }
        public string Alamat { get; set; }
        public string Email { get; set; }
    }
}
