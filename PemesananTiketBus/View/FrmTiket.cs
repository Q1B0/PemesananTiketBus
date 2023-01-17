using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PemesananTiketBus.Controller;
using PemesananTiketBus.Model.Entity;

namespace PemesananTiketBus.View
{
    public partial class FrmTiket : Form
    {
        private PelangganController controllerPelanggan = new PelangganController();
        private BusController controllerBus = new BusController();
        private TiketController controller = new TiketController();
        private Tiket tiket = new Tiket();
        private List<Tiket> listOfTiket = new List<Tiket>();
        public FrmTiket()
        {
            InitializeComponent();
            InitListView();
            LoadData();
            Reset();
        }

        // load data dan tampilkan ke listview
        private void LoadData()
        {
            listTiket.Items.Clear();
            listOfTiket = controller.ReadAll();
            foreach(var item in listOfTiket)
            {
                var no = listTiket.Items.Count + 1;
                var listItem = new ListViewItem(no.ToString());
                listItem.SubItems.Add(item.IDTiket);
                listItem.SubItems.Add(item.Pelanggan.Nama);
                listItem.SubItems.Add(item.Bus.Nama);
                listItem.SubItems.Add(item.Bus.Rute);
                listItem.SubItems.Add(item.JumlahTiket.ToString());
                listItem.SubItems.Add(item.TanggalBerangkat.ToString("dd/MM/yy"));

                listTiket.Items.Add(listItem);
            }
        }
        private void InitListView()
        {
            listTiket.View = System.Windows.Forms.View.Details;
            listTiket.FullRowSelect = true;
            listTiket.GridLines = true;

            listTiket.Columns.Add("No.", 30, HorizontalAlignment.Center);
            listTiket.Columns.Add("ID Tiket", 100, HorizontalAlignment.Center);
            listTiket.Columns.Add("Nama Pelanggan", 150, HorizontalAlignment.Center);
            listTiket.Columns.Add("Nama Bus", 150, HorizontalAlignment.Center);
            listTiket.Columns.Add("Rute", 130, HorizontalAlignment.Center);
            listTiket.Columns.Add("Jumlah Tiket", 80, HorizontalAlignment.Center);
            listTiket.Columns.Add("Tanggal Berangkat", 130, HorizontalAlignment.Center);
        }

        // button cari pelanggan berdasarkan id pelanggan
        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                int idPelanggan = Convert.ToInt32(textIDPelanggan.Text);
                tiket.Pelanggan = controllerPelanggan.ReadById(idPelanggan);
            }
            catch
            {

            }
            if (tiket.Pelanggan != null)
            {
                textNamaPelanggan.Text = tiket.Pelanggan.Nama;
            }
            else
            {
                MessageBox.Show("Data Pelanggan tidak ditemukan", "Peringatan", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
            }
        }

        // button cari bus berdasarkan id pelanggan
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int idBus = Convert.ToInt32(textIDBus.Text);
                tiket.Bus = controllerBus.ReadById(idBus);
            }
            catch
            {

            }
            if (tiket.Bus != null)
            {
                textNamaBus.Text = tiket.Bus.Nama;
                textRute.Text = tiket.Bus.Rute;

                CalcHargaTotal();
            }
            else
            {
                MessageBox.Show("Data Bus tidak ditemukan", "Peringatan", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

            tiket.IDTiket = textIDTiket.Text;
            try
            {
                tiket.JumlahTiket = Convert.ToInt32(textJumlahTiket.Text);
            }
            catch
            {

            }
            tiket.Keterangan = textKeterangan.Text;
            tiket.TanggalBerangkat = dateBerangkat.Value;
            tiket.TanggalTiket = dateBeli.Value;

            int result = controller.Create(tiket);
            if (result > 0)
            {
                MessageBox.Show("Behasil order tiket", "Peringatan", MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation);
                LoadData();

                Reset();
            }
            else
            {
                MessageBox.Show("Gagal order tiket", "Peringatan", MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation);
            }
        }

        // method untuk melakukan kalkulasi harga total sesuai jumlah tiket yang di input
        private void CalcHargaTotal()
        {
            try
            {
                if (tiket.Bus != null)
                    if (tiket.Bus.Harga != 0)
                        textHargaTotal.Text = (tiket.Bus.Harga * Convert.ToInt32(textJumlahTiket.Text)).ToString();

            }
            catch 
            {
                textHargaTotal.Text = "0";
            }
        }

        private void textJumlahTiket_KeyUp(object sender, KeyEventArgs e)
        {
            CalcHargaTotal();
        }

        // pilih data dari listview dan munculkan ke textbox
        private void listTiket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTiket.SelectedIndices.Count>0)
            {
                tiket = listOfTiket[listTiket.SelectedIndices[0]];
                textIDTiket.Text = tiket.IDTiket;
                dateBeli.Value = tiket.TanggalTiket;
                textIDPelanggan.Text = tiket.Pelanggan.IdPelanggan;
                textNamaPelanggan.Text = tiket.Pelanggan.Nama;
                textIDBus.Text = tiket.Bus.IDBus;
                textNamaBus.Text = tiket.Bus.Nama;
                textRute.Text = tiket.Bus.Rute;
                dateBerangkat.Value= tiket.TanggalBerangkat;
                textJumlahTiket.Text = tiket.JumlahTiket.ToString();
                CalcHargaTotal();
                textKeterangan.Text = tiket.Keterangan;
                btnBatal.Enabled = true;
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            if (listTiket.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Yakin ingin Hapus Data Tiket?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil data tiket yang mau dihapus dari collection
                    Tiket tiket = listOfTiket[listTiket.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(tiket);
                    if (result > 0) LoadData();

                    Reset();
                }
            }

            else // data belum dipilih
            {
                MessageBox.Show("Data Tiket belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        // method untuk reset textbox agar kosong
        private void Reset()
        {
            textIDTiket.Clear();
            dateBeli.ResetText();
            textIDPelanggan.Clear();
            textNamaPelanggan.Clear();
            textIDBus.Clear();
            textNamaBus.Clear();
            textRute.Clear();
            dateBerangkat.ResetText();
            textHargaTotal.Clear();
            textJumlahTiket.Clear();
            textKeterangan.Clear();

            textIDTiket.Focus();
            btnBatal.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset(); // panggil method reset
        }
    }
}
