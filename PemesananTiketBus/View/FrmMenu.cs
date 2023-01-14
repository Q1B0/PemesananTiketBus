using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemesananTiketBus.View
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnBus_Click(object sender, EventArgs e)
        {
            FrmDataBus frm = new FrmDataBus();
            frm.ShowDialog();
        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            FrmDataPelanggan frm = new FrmDataPelanggan();
            frm.ShowDialog();
        }

        private void btnTiket_Click(object sender, EventArgs e)
        {
            FrmTiket frm = new FrmTiket();
            frm.ShowDialog();
        }

        private void btnPembayaran_Click(object sender, EventArgs e)
        {
            FrmPembayaran frm = new FrmPembayaran();
            frm.ShowDialog();
        }
    }
}
