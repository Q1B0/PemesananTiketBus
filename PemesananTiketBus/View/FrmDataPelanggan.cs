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
    public partial class FrmDataPelanggan : Form
    {
        // Deklarasi objek controller dari kelas PelangganController
        private PelangganController controller = new PelangganController();

        // Deklarasi objek listOfPelanggan dari tipe List<Pelanggan>
        private List<Pelanggan> listOfPelanggan = new List<Pelanggan>();

        // Deklarasi objek pelanggan dari tipe Pelanggan
        private Pelanggan pelanggan = new Pelanggan();

        // Konstruktor dari FrmDataPelanggan
        public FrmDataPelanggan()
        {
            // Memanggi method untuk inisialisasi setiap komponen
            InitializeComponent();

            // Memanggi method untuk inisialisasi tampilan ListView
            InisialisasiListView();

            // Memanggil method untuk memuat data pelanggan dari database
            LoadDataPelanggan();

            // Memanggil method untuk mereset form ke kondisi awal
            ResetForm();
        }

        // Membuat method yang digunakan untuk inisialisasi tampilan ListView
        private void InisialisasiListView()
        {
            // Menetapkan tampilan ListView sebagai detail
            listDataPelanggan.View = System.Windows.Forms.View.Details;

            // Menetapkan ListView agar memilih seluruh baris saat satu baris dipilih
            listDataPelanggan.FullRowSelect = true;

            //Menampilkan garis grid pada ListView
            listDataPelanggan.GridLines = true;

            // Menambahkan kolom-kolom pada list view dan menentukan lebar dan posisi tiap kolom
            listDataPelanggan.Columns.Add("No.", 30, HorizontalAlignment.Center);
            listDataPelanggan.Columns.Add("ID", 60, HorizontalAlignment.Center);
            listDataPelanggan.Columns.Add("Nama", 150, HorizontalAlignment.Center);
            listDataPelanggan.Columns.Add("No_Tlp", 90, HorizontalAlignment.Center);
            listDataPelanggan.Columns.Add("Alamat", 100, HorizontalAlignment.Center);
            listDataPelanggan.Columns.Add("Email", 135, HorizontalAlignment.Center);
        }

        // Membuat method yang digunakan untuk memuat data pelanggan dari database
        private void LoadDataPelanggan()
        {
            // Menghapus semua item pada ListView
            listOfPelanggan = controller.ReadAll();

            // Membersihkan list view sebelum menampilkan data baru
            listDataPelanggan.Items.Clear();

            // Perulangan untuk mengambil setiap objek pelanggan dari listOfPelanggan
            foreach (var pelanggan in listOfPelanggan)
            {
                // Menghitung urutan nomor dari setiap item pada ListView
                var noUrut = listDataPelanggan.Items.Count + 1;

                // Membuat objek item dari tipe ListViewItem
                var item = new ListViewItem(noUrut.ToString());

                // Menambahkan subitem pada objek item dengan data dari objek pelanggan
                item.SubItems.Add(pelanggan.IdPelanggan);
                item.SubItems.Add(pelanggan.Nama);
                item.SubItems.Add(pelanggan.No_tlp);
                item.SubItems.Add(pelanggan.Alamat);
                item.SubItems.Add(pelanggan.Email);

                // Menambahkan objek item ke ListView
                listDataPelanggan.Items.Add(item);
            }
        }

        // Method yang akan dijalankan saat tombol Simpan diklik
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Mengisi properti dari objek pelanggan dengan data dari form
            pelanggan.IdPelanggan = textIDPelanggan.Text;
            pelanggan.Nama = textNama.Text;
            pelanggan.No_tlp = textNoTelp.Text;
            pelanggan.Alamat = textAlamat.Text;
            pelanggan.Email = textEmail.Text;

            // Deklarasi variabel result untuk menyimpan hasil dari method Create()
            int result = 0;

            // Menjalankan method Create() dari objek controller dengan parameter objek pelanggan
            result = controller.Create(pelanggan);

            // Jika hasil dari method Create() lebih dari 0 (berhasil)
            if (result > 0)
            {
                // Memuat ulang data pelanggan pada ListView
                LoadDataPelanggan();

                // Menjalankan tombol Reset secara otomatis
                btnReset.PerformClick();
            }
        }

        // Method yang akan dijalankan saat tombol Update diklik
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Jika ada item yang dipilih pada ListView
            if (listDataPelanggan.SelectedItems.Count > 0)
            {
                // Mengisi properti dari objek pelanggan dengan data dari form
                pelanggan.IdPelanggan = textIDPelanggan.Text;
                pelanggan.Nama = textNama.Text;
                pelanggan.No_tlp = textNoTelp.Text;
                pelanggan.Alamat = textAlamat.Text;
                pelanggan.Email = textEmail.Text;

                // Deklarasi variabel result untuk menyimpan hasil dari method Update()
                int result = 0;

                // Menjalankan method Update() dari objek controller dengan parameter objek pelanggan
                result = controller.Update(pelanggan);

                // Jika hasil dari method Update() lebih dari 0 (berhasil)
                if (result > 0) 
                {
                    // Memuat ulang data pelanggan pada ListView
                    LoadDataPelanggan();

                    // Menjalankan tombol Reset secara otomatis
                    btnReset.PerformClick();
                }
            }

            // Jika tidak ada item yang dipilih pada ListView
            else
            {
                // Menampilkan pesan peringatan
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        // Method yang akan dijalankan saat tombol Delete diklik
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Jika ada item yang dipilih pada ListView
            if (listDataPelanggan.SelectedItems.Count > 0)
            {
                // Menampilkan konfirmasi untuk menghapus data
                var konfirmasi = MessageBox.Show("Yakin ingin Hapus Data Pelanggan?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                //Jika user menekan tombol Yes
                if (konfirmasi == DialogResult.Yes)
                {
                    // Mendapatkan objek pelanggan yang dipilih dari listOfPelanggan
                    Pelanggan pelanggan = listOfPelanggan[listDataPelanggan.SelectedIndices[0]];

                    // Menjalankan method Delete() dari objek controller dengan parameter objek pelanggan
                    var result = controller.Delete(pelanggan);

                    // Jika hasil dari method Delete() lebih dari 0 (berhasil)
                    if (result > 0) LoadDataPelanggan();

                    // Menjalankan tombol Reset secara otomatis
                    btnReset.PerformClick();
                }
            }

            // Jika tidak ada item yang dipilih pada ListView
            else
            {
                // Menampilkan pesan peringatan
                MessageBox.Show("Data Pelanggan belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Method yang akan dijalankan saat ada perubahan pilihan pada ListView
        private void listDataPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Jika ada item yang dipilih pada ListView
            if (listDataPelanggan.SelectedIndices.Count > 0)
            {
                // Mendapatkan objek pelanggan yang dipilih dari listOfPelanggan
                pelanggan = listOfPelanggan[listDataPelanggan.SelectedIndices[0]];

                // Menampilkan data dari objek pelanggan ke form
                textIDPelanggan.Text = pelanggan.IdPelanggan;
                textIDPelanggan.Enabled = false;
                textNama.Text = pelanggan.Nama;
                textNoTelp.Text = pelanggan.No_tlp;
                textAlamat.Text = pelanggan.Alamat;
                textEmail.Text = pelanggan.Email;

                // Mengaktifkan tombol Delete dan Update
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true; 
            }
        }

        // Membuat method untuk mengembalikan Form ke kondisi awal
        private void ResetForm()
        {
            // Membersihkan inputan pada form
            textIDPelanggan.Clear();
            textIDPelanggan.Enabled = true;
            textNama.Clear();
            textNoTelp.Clear();
            textAlamat.Clear();
            textEmail.Clear();

            //Menetapkan fokus pada textIDPelanggan
            textIDPelanggan.Focus();

            // Menonaktifkan tombol Delete dan Update
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        // Method yang akan dijalankan saat tombol Reset diklik
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Memanggil method ResetForm()
            ResetForm();
        }
    }
}
