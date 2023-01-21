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
        // Deklarasi objek controller dari kelas PembayaranController yang 
        // digunakan untuk mengambil data pembayaran
        private PembayaranController controller = new PembayaranController();

        // Deklarasi list untuk menampung data pembayaran
        private List<Pembayaran> listOfPembayaran = new List<Pembayaran>();

        // Method yang akan dijalankan saat form dibuka
        public FrmLaporan()
        {
            // Inisialisasi komponen-komponen pada form
            InitializeComponent();

            // Memanggil method untuk inisialisasi tampilan list view
            InitListView();

            // Set radio button "Semua" sebagai yang dipilih secara default
            radioButtonSemua.Checked = true;

            // Memanggil method untuk mengambil dan menampilkan data pembayaran
            LoadData();
        }

        // Method untuk inisialisasi tampilan list view
        private void InitListView()
        {
            // Set tampilan list view sebagai "Details"
            listLaporan.View = System.Windows.Forms.View.Details;

            // Memungkinkan pengguna untuk memilih baris penuh saat mengklik baris
            listLaporan.FullRowSelect = true;
            listLaporan.FullRowSelect = true;

            // Menampilkan garis grid pada list view
            listLaporan.GridLines = true;

            // Menambahkan kolom-kolom pada list view dan menentukan lebar dan posisi tiap kolom
            listLaporan.Columns.Add("No.", 30, HorizontalAlignment.Center);
            listLaporan.Columns.Add("ID Bayar", 100, HorizontalAlignment.Center);
            listLaporan.Columns.Add("Tanggal Bayar", 150, HorizontalAlignment.Center);
            listLaporan.Columns.Add("ID Tiket", 150, HorizontalAlignment.Center);
            listLaporan.Columns.Add("Nama Pelanggan", 130, HorizontalAlignment.Center);
            listLaporan.Columns.Add("Total Bayar", 80, HorizontalAlignment.Center);
        }

        // Method untuk mengambil dan menampilkan data pembayaran
        private void LoadData()
        {
            // Membersihkan list view sebelum menampilkan data baru
            listLaporan.Items.Clear();

            // Jika radio button "Semua" dipilih
            if(radioButtonSemua.Checked) 
            {
                // Ambil semua data pembayaran
                listOfPembayaran = controller.ReadAll();
            } 
            
            // Jika radio button "ID Pembayaran" dipilih dan text box "ID Pembayaran" tidak kosong
            else if(radioButtonID.Checked && !string.IsNullOrEmpty(textIDPembayaran.Text))
            { 
                // Ambil data pembayaran berdasarkan id pembayaran
                listOfPembayaran = controller.ReadById(Convert.ToInt32(textIDPembayaran.Text));
            } 
            
            // Jika radio button "Nama Pelanggan" dipilih
            else if(radioButtonNama.Checked)
            { 
                // Ambil data pembayaran berdasarkan nama pelanggan
                listOfPembayaran = controller.ReadByNama(textNamaPelanggan.Text);
            }

            // Looping setiap data pembayaran yang didapatkan
            foreach (var item in listOfPembayaran)
            {
                // Menghitung nomor urut data pembayaran
                var no = listLaporan.Items.Count + 1;

                // Membuat item baru pada list view
                var listItem = new ListViewItem(no.ToString());

                // Menambahkan data pembayaran ke list view
                listItem.SubItems.Add(item.IDPembayaran);
                listItem.SubItems.Add(item.Tiket.Pelanggan.Nama);
                listItem.SubItems.Add(item.Tiket.IDTiket);
                listItem.SubItems.Add(item.TotalBayar.ToString());
                listItem.SubItems.Add(item.TanggalBayar.ToString("dd/MM/yy"));

                // Menambahkan item ke list view
                listLaporan.Items.Add(listItem);
            }

            if(listOfPembayaran.Count==0) MessageBox.Show("Data Pembayaran tidak ditemukan", "Peringatan", MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }

        // Event handler untuk saat tombol Enter ditekan pada text box ID Pembayaran
        private void textIDPembayaran_KeyUp(object sender, KeyEventArgs e)
        {
            // Jika tombol Enter ditekan, Klik tombol Tampilkan Data
            if (e.KeyCode == Keys.Enter) btnTampilkanData.PerformClick();
        }

        // Event handler untuk saat tombol Enter ditekan pada text box Nama Pelanggan
        private void textNamaPelanggan_KeyUp(object sender, KeyEventArgs e)
        {
            // Jika tombol Enter ditekan, Klik tombol Tampilkan Data
            if (e.KeyCode == Keys.Enter) btnTampilkanData.PerformClick();
        }

        // Event handler untuk saat tombol Tampilkan Data diklik
        private void btnTampilakData_Click(object sender, EventArgs e)
        {
            // Memanggil method LoadData() untuk menampilkan data pembayaran 
            // sesuai dengan kriteria pencarian yang dipilih
            LoadData();

            // Membersihkan inputan pada text box ID Pembayaran
            textIDPembayaran.Clear();

            // Membersihkan inputan pada text box ID Pelanggan
            textNamaPelanggan.Clear();
        }
    }
}
