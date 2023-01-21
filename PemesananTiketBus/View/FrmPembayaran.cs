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
        // Deklarasi objek controllerPembayran dari kelas PemabayranController
        private PembayaranController controllerPembayaran = new PembayaranController();

        // Deklarasi objek controllerTiket dari kelas TiketController
        private TiketController controllerTiket = new TiketController();

        // Deklarasi objek pembayaran dari kelas Pembayaran
        private Pembayaran pembayaran = new Pembayaran();

        // Deklarasi objek listOfPembayaran sebagai list dari kelas Pembayaran
        private List<Pembayaran> listOfPembayaran = new List<Pembayaran>();

        // Method yang akan dipanggil saat form dibuka
        public FrmPembayaran()
        {
            // Memanggil method InitializeComponent untuk menginisialisasi komponen yang digunakan dalam form
            InitializeComponent();

            // Mematikan fitur teks di textNamaPelanggan
            textNamaPelanggan.Enabled = false;

            // Mematikan fitur teks di textTotalBayar
            textTotalBayar.Enabled = false;

            // Memanggil method InitListView untuk mengatur tampilan listview
            InitListView();

            // Memanggil method LoadData untuk mengambil data dari database
            LoadData();

            // Memanggil method Reset untuk mengembalikan semua input ke kondisi awal
            Reset();
        }

        // Membuat event ketika button cari ID tiket diklik
        private void btnCariIDTiket_Click(object sender, EventArgs e)
        {
            // Mencoba untuk mengambil data tiket berdasarkan ID yang diinputkan
            try
            {
                pembayaran.Tiket = controllerTiket.ReadById(Convert.ToInt32(textIDTiket.Text));
            }

            // Jika terjadi kesalahan, maka akan masuk ke catch
            catch
            {

            }

            // Jika data tiket yang diinputkan tidak ditemukan
            if(pembayaran.Tiket == null)
            {
                // Muncul pesan peringatan bahwa tiket tidak ditemukan
                MessageBox.Show("Tiket tidak ditemukan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 

            // Jika data tiket ditemukan
            else
            {
                // Maka akan menampilkan nama pelanggan dan total bayar di textbox yang sesuai
                textNamaPelanggan.Text = pembayaran.Tiket.Pelanggan.Nama;
                textTotalBayar.Text = pembayaran.TotalBayar.ToString();
            }
        }

        // Load data dan tampilkan ke listview
        private void LoadData()
        {
            // Menghapus semua item di list view pembayaran
            listPembayaran.Items.Clear();

            // Mendapatkan list dari data pembayaran yang ada di database
            listOfPembayaran = controllerPembayaran.ReadAll();

            // Looping setiap data pembayaran yang ada di list
            foreach (var item in listOfPembayaran)
            {
                // Mendapatkan nomor urut dari data pembayaran
                var no = listPembayaran.Items.Count + 1;

                // Membuat objek baru dari list view item
                var listItem = new ListViewItem(no.ToString());

                // Menambahkan sub item untuk setiap data pembayaran
                listItem.SubItems.Add(item.IDPembayaran);
                listItem.SubItems.Add(item.Tiket.Pelanggan.Nama);
                listItem.SubItems.Add(item.Tiket.IDTiket);
                listItem.SubItems.Add(item.TotalBayar.ToString());
                listItem.SubItems.Add(item.TanggalBayar.ToString("dd/MM/yy"));

                // Menambahkan objek list view item ke list view pembayaran
                listPembayaran.Items.Add(listItem);
            }
        }

        // Method untuk inisialisasi list view untuk menampilkan data pembayaran
        private void InitListView()
        {
            // Mengatur tampilan list view menjadi detail
            listPembayaran.View = System.Windows.Forms.View.Details;

            // Mengaktifkan pilihan untuk menampilkan seluruh baris ketika dipilih
            listPembayaran.FullRowSelect = true;

            //Mengaktifkan garis grid di list view
            listPembayaran.GridLines = true;

            // Mengaktifkan garis grid di list view
            listPembayaran.Columns.Add("No.", 30, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("ID Bayar", 100, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("Nama Pelanggan", 130, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("ID Tiket", 150, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("Total Bayar", 80, HorizontalAlignment.Center);
            listPembayaran.Columns.Add("Tanggal Bayar", 150, HorizontalAlignment.Center);
        }

        // Membuat event handler cuntuk buttob Bayar
        private void btnBayar_Click(object sender, EventArgs e)
        {
            pembayaran.IDPembayaran = textIDBayar.Text;
            pembayaran.TanggalBayar = dateBayar.Value;
            controllerPembayaran.Create(pembayaran);

            LoadData();
            Reset();
        }

        // Deklarasi method yang akan dijalankan ketika tombol "btnLaporan" diklik.
        private void btnLaporan_Click(object sender, EventArgs e)
        {
            // Deklarasi dan instansiasi objek baru dari kelas "FrmLaporan"
            FrmLaporan frm = new FrmLaporan();

            // Perintah menampilkan objek "frm" sebagai form dialog
            frm.ShowDialog();
        }

        // Deklarasi method Reset
        private void Reset()
        {
            // Mengosongkan isi textbox dan mengatur ulang tanggal pada dateBayar
            textIDBayar.Clear();
            dateBayar.ResetText();
            textIDTiket.Clear();
            textNamaPelanggan.Clear();
            textTotalBayar.Clear();

            // Memberikan fokus pada textbox dengan ID textIDBayar
            textIDBayar.Focus();

            // Menonaktifkan tombol dengan ID btnDelete
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

            else // Data belum dipilih
            {
                MessageBox.Show("Data Bus belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Ketika ada item yang dipilih dari listbox dengan ID listPembayaran, maka akan dilakukan proses pengambilan
        // data dari objek pembayaran yang dipilih dan menampilkannya pada form.
        private void listPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Jika listbox tidak memiliki item yang dipilih, maka tidak akan dilakukan apa-apa.
            if (listPembayaran.SelectedIndices.Count > 0)
            {
                // Mengambil objek pembayaran yang dipilih dari listOfPembayaran berdasarkan indeks yang dipilih dari listbox
                pembayaran = listOfPembayaran[listPembayaran.SelectedIndices[0]];

                // Menampilkan seluruh item pada textbox
                textIDBayar.Text = pembayaran.IDPembayaran;
                dateBayar.Value = pembayaran.TanggalBayar;
                textIDTiket.Text = pembayaran.Tiket.IDTiket;
                textNamaPelanggan.Text = pembayaran.Tiket.Pelanggan.Nama;
                textTotalBayar.Text = pembayaran.TotalBayar.ToString();

                // Mengaktifkan tombol dengan ID btnDelete
                btnDelete.Enabled = true;
            }
        }
    }
}
