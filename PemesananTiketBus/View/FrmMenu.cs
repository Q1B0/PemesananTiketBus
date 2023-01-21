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
        // Membuat method constructor yang digunakan untuk menginisialisasi komponen-komponen
        public FrmMenu()
        {
            // Membuat method untuk menginisialisasi seluruh komponen
            InitializeComponent();
        }

        // Method ini akan dijalankan ketika tombol dengan ID btnBus diklik.
        private void btnBus_Click(object sender, EventArgs e)
        {
            // Membuat objek baru dari form FrmDataBus
            FrmDataBus frm = new FrmDataBus();

            // Menampilkan form FrmDataBus dengan menggunakan ShowDialog()
            frm.ShowDialog();
        }

        // Method ini akan dijalankan ketika tombol dengan ID btnPelanggan diklik.
        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            // Membuat objek baru dari form FrmDataPelanggan
            FrmDataPelanggan frm = new FrmDataPelanggan();

            // Menampilkan form FrmDataPelanggan dengan menggunakan ShowDialog()
            frm.ShowDialog();
        }

        // Method ini akan dijalankan ketika tombol dengan ID btnTiket diklik.
        private void btnTiket_Click(object sender, EventArgs e)
        {
            // Membuat objek baru dari form FrmTiket
            FrmTiket frm = new FrmTiket();

            // Menampilkan form FrmTiket dengan menggunakan ShowDialog()
            frm.ShowDialog();
        }

        // Method ini akan dijalankan ketika tombol dengan ID btnPembayaran diklik.
        private void btnPembayaran_Click(object sender, EventArgs e)
        {
            // Membuat objek baru dari form FrmPembayaran
            FrmPembayaran frm = new FrmPembayaran();

            // Menampilkan form FrmPembayaran dengan menggunakan ShowDialog()
            frm.ShowDialog();
        }
    }
}
