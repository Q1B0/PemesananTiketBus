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
            Reset();
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
            listPembayaran.Columns.Add("Nama Pelanggan", 130, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("ID Tiket", 150, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("Total Bayar", 80, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("Tanggal Bayar", 150, HorizontalAlignment.Center);
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            pembayaran.IDPembayaran = textIDBayar.Text;
            pembayaran.TanggalBayar = dateBayar.Value;
            controllerPembayaran.Create(pembayaran);

            LoadData();
            Reset();
        }

        // button untuk pergi ke form laporan
        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FrmLaporan frm = new FrmLaporan();
            frm.ShowDialog();
        }
        private void Reset()
        {
            textIDBayar.Clear();
            dateBayar.ResetText();
            textIDTiket.Clear();
            textNamaPelanggan.Clear();
            textTotalBayar.Clear();

            textIDBayar.Focus();
            btnDelete.Enabled = false;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listPembayaran.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Yakin ingin Hapus Data Pembayaran?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek bus yang mau dihapus dari collection
                    Pembayaran pembayaran = listOfPembayaran[listPembayaran.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controllerPembayaran.Delete(pembayaran);
                    if (result > 0) LoadData();

                    // reset form input, utk persiapan input data berikutnya
                    Reset();
                }
            }

            else // data belum dipilih
            {
                MessageBox.Show("Data Bus belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void listPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPembayaran.SelectedIndices.Count > 0)
            {
                pembayaran = listOfPembayaran[listPembayaran.SelectedIndices[0]];
                textIDBayar.Text = pembayaran.IDPembayaran;
                dateBayar.Value = pembayaran.TanggalBayar;
                textIDTiket.Text = pembayaran.Tiket.IDTiket;
                textNamaPelanggan.Text = pembayaran.Tiket.Pelanggan.Nama;
                textTotalBayar.Text = pembayaran.TotalBayar.ToString();
                btnDelete.Enabled = true;
            }
        }
    }
}
