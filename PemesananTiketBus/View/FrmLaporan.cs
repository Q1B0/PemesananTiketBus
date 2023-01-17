using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PemesananTiketBus.Model.Entity;
using PemesananTiketBus.Controller;
namespace PemesananTiketBus.View
{
    public partial class FrmLaporan : Form
    {
        private PembayaranController controller = new PembayaranController();
        private List<Pembayaran> listOfPembayaran = new List<Pembayaran>();
        public FrmLaporan()
        {
            InitializeComponent();
            InitListView();
            radioButtonSemua.Checked = true; // tampilkan semua data pembayaran saat form laporan dibuka
            LoadData();
        }
        private void InitListView()
        {
            listLaporan.View = System.Windows.Forms.View.Details;
            listLaporan.FullRowSelect = true;
            listLaporan.GridLines = true;

            listLaporan.Columns.Add("No.", 30, HorizontalAlignment.Center);
            listLaporan.Columns.Add("ID Bayar", 100, HorizontalAlignment.Center);
            listLaporan.Columns.Add("Tanggal Bayar", 150, HorizontalAlignment.Center);
            listLaporan.Columns.Add("ID Tiket", 150, HorizontalAlignment.Center);
            listLaporan.Columns.Add("Nama Pelanggan", 130, HorizontalAlignment.Center);
            listLaporan.Columns.Add("Total Bayar", 80, HorizontalAlignment.Center);
        }

        // load data dan tampilkan ke listview
        private void LoadData()
        {
            listLaporan.Items.Clear();
            if(radioButtonSemua.Checked) 
            { // cari semua data pembayaran
                listOfPembayaran = controller.ReadAll();
            } else if(radioButtonID.Checked && !string.IsNullOrEmpty(textIDPembayaran.Text))
            { // cari data pembayaran berdasarkan id pembayaran
                listOfPembayaran = controller.ReadById(Convert.ToInt32(textIDPembayaran.Text));
            } else if(radioButtonNama.Checked)
            { // cari data pembayaran berdasarkan nmaa pelanggan
                listOfPembayaran = controller.ReadByNama(textNamaPelanggan.Text);
            }
            foreach (var item in listOfPembayaran)
            {
                var no = listLaporan.Items.Count + 1;
                var listItem = new ListViewItem(no.ToString());
                listItem.SubItems.Add(item.IDPembayaran);
                listItem.SubItems.Add(item.Tiket.Pelanggan.Nama);
                listItem.SubItems.Add(item.Tiket.IDTiket);
                listItem.SubItems.Add(item.TotalBayar.ToString());
                listItem.SubItems.Add(item.TanggalBayar.ToString("dd/MM/yy"));

                listLaporan.Items.Add(listItem);
            }

            if(listOfPembayaran.Count==0) MessageBox.Show("Data Pembayaran tidak ditemukan", "Peringatan", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
        }

        // saat tekan tombol enter pada keyboard sama saja menekan tombol Tampilkan Data
        private void textIDPembayaran_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnTampilkanData.PerformClick();
        }

        // saat tekan tombol enter pada keyboard sama saja menekan tombol Tampilkan Data
        private void textNamaPelanggan_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter) btnTampilkanData.PerformClick();
        }

        // button untuk menampikan data pembayaran
        private void btnTampilakData_Click(object sender, EventArgs e)
        {
            LoadData();
            textIDPembayaran.Clear();
            textNamaPelanggan.Clear();
        }
    }
}
