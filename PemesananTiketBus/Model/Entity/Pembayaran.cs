using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemesananTiketBus.Model.Entity
{
    public class Pembayaran
    {
        public string IDPembayaran { get; set; }
        public DateTime TanggalBayar { get; set; }
        public int TotalBayar {
            get {
                return Tiket.Bus.Harga * Tiket.JumlahTiket;
            }
        }
        public Tiket Tiket { get; set; }
    }
}
