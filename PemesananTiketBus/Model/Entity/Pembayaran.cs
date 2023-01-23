using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemesananTiketBus.Model.Entity
{
    // Deklarasi kelas Pembayaran
    public class Pembayaran
    {
        // Membuat properti yang dapat diakses dari luar kelas
        public string IDPembayaran { get; set; }
        public DateTime TanggalBayar { get; set; }
        public int TotalBayar {
            get {
                // kode yang digunakan untuk menghitung total harga yang harus dibayar
                return Tiket.Bus.Harga * Tiket.JumlahTiket;
            }
        }
        public Tiket Tiket { get; set; }
    }
}
