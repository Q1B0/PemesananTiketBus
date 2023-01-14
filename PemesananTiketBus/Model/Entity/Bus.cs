using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemesananTiketBus.Model.Entity
{
    // p info
    public class Bus
    {
        public string IDBus { get; set; }
        public string Nama { get; set; }
        public string Rute { get; set; }
        public int Harga { get; set; }
    }
}
