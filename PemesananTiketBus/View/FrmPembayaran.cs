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
using PemesananTiketBus.Model.Repository;
using PemesananTiketBus.Controller;

namespace PemesananTiketBus.View
{
    public partial class FrmPembayaran : Form
    {
        private PembayaranController controllerPembayaran = new PembayaranController();
        private TiketController controllerTiket = new TiketController();
        private Pembayaran pembayaran = new Pembayaran();
        private List<Pembayaran> listOfPembayaran = new List<Pembayaran>();
        public FrmPembayaran()
        {
            InitializeComponent();
            textNamaPelanggan.Enabled = false;
            textTotalBayar.Enabled = false;
            InitListView();
            LoadData();
        }

        
        private void btnCariIDTiket_Click(object sender, EventArgs e)
        {
            try
            {
                pembayaran.Tiket = controllerTiket.ReadById(Convert.ToInt32(textIDTiket.Text));
            }
            catch
            {

            }
            if(pembayaran.Tiket == null)
            {
                MessageBox.Show("Tiket tidak ditemukan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else
            {
                textNamaPelanggan.Text = pembayaran.Tiket.Pelanggan.Nama;
                textTotalBayar.Text = pembayaran.TotalBayar.ToString();
            }
        }

        // load data dan tampilkan ke listview
        private void LoadData()
        {
            listPembayaran.Items.Clear();
            listOfPembayaran = controllerPembayaran.ReadAll();
            foreach (var item in listOfPembayaran)
            {
                var no = listPembayaran.Items.Count + 1;
                var listItem = new ListViewItem(no.ToString());
                listItem.SubItems.Add(item.IDPembayaran);
                listItem.SubItems.Add(item.Tiket.Pelanggan.Nama);
                listItem.SubItems.Add(item.Tiket.IDTiket);
                listItem.SubItems.Add(item.TotalBayar.ToString());
                listItem.SubItems.Add(item.TanggalBayar.ToString("dd/MM/yy"));

                listPembayaran.Items.Add(listItem);
            }
        }

        private void InitListView()
        {
            listPembayaran.View = System.Windows.Forms.View.Details;
            listPembayaran.FullRowSelect = true;
            listPembayaran.GridLines = true;

            listPembayaran.Columns.Add("No.", 30, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("ID Bayar", 100, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("Tanggal Bayar", 150, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("ID Tiket", 150, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("Nama Pelanggan", 130, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("Total Bayar", 80, HorizontalAlignment.Center);
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            pembayaran.IDPembayaran = textIDBayar.Text;
            pembayaran.TanggalBayar = dateBayar.Value;
            controllerPembayaran.Create(pembayaran);

            LoadData();
        }

        // button untuk pergi ke form laporan
        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FrmLaporan frm = new FrmLaporan();
            frm.ShowDialog();
        }
    }
}
