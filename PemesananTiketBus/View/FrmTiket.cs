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
        //Deklarasi objek controllerPelanggan dari kelas PelangganController
        private PelangganController controllerPelanggan = new PelangganController();

        //Deklarasi objek controllerBus dari kelas BusController
        private BusController controllerBus = new BusController();

        //Deklarasi objek controller dari kelas TiketController
        private TiketController controller = new TiketController();

        //Deklarasi objek tiket dari kelas Tiket
        private Tiket tiket = new Tiket();

        //Deklarasi objek listOfTiket sebagai list dari kelas Tiket
        private List<Tiket> listOfTiket = new List<Tiket>();

        //Method yang akan dipanggil saat form dibuka
        public FrmTiket()
        {
            //Menjalankan method InitializeComponent untuk inisialisasi komponen pada form
            InitializeComponent();

            //Menjalankan method InitListView untuk inisialisasi tampilan ListView
            InitListView();

            //Menjalankan method LoadData untuk memuat data dari database
            LoadData();

            //Menjalankan method Reset untuk mengatur kondisi awal form
            Reset();
        }

        // Mthod mengambil data dari objek
        private void LoadData()
        {
            //Menghapus semua item yang ada di listTiket
            listTiket.Items.Clear();

            //Memanggil method ReadAll() dari controller untuk mendapatkan semua data tiket yang ada
            listOfTiket = controller.ReadAll();

            //Melakukan perulangan untuk setiap data tiket dalam listOfTiket
            foreach(var item in listOfTiket)
            {
                //Menghitung jumlah item yang ada di listTiket dan menambahkan 1
                var no = listTiket.Items.Count + 1;

                //Membuat objek baru dari ListViewItem dengan parameter nomor
                var listItem = new ListViewItem(no.ToString());
                
                //Menambahkan subitem IDTiket ke listItem
                listItem.SubItems.Add(item.IDTiket);

                //Menambahkan subitem Nama Pelanggan ke listItem
                listItem.SubItems.Add(item.Pelanggan.Nama);

                //Menambahkan subitem Nama Bus ke listItem
                listItem.SubItems.Add(item.Bus.Nama);

                //Menambahkan subitem Rute Bus ke listItem
                listItem.SubItems.Add(item.Bus.Rute);

                //Menambahkan subitem Jumlah Tiket ke listItem
                listItem.SubItems.Add(item.JumlahTiket.ToString());

                //Menambahkan subitem Tanggal Berangkat dengan format "dd/MM/yy" ke listItem
                listItem.SubItems.Add(item.TanggalBerangkat.ToString("dd/MM/yy"));

                //Menambahkan listItem ke listTiket
                listTiket.Items.Add(listItem);
            }
        }
        
        // Method untuk menentukan properti-properti dari ListView/tampilan  
        private void InitListView()
        {
            // Mengatur tampilan listview menjadi detail
            listTiket.View = System.Windows.Forms.View.Details;

            // Membuat listview dapat dipilih seluruh barisnya
            listTiket.FullRowSelect = true;

            // Membuat garis grid pada listview
            listTiket.GridLines = true;

            // Menambahkan kolom "No." pada listview dengan lebar 30px dan rata tengah
            listTiket.Columns.Add("No.", 30, HorizontalAlignment.Center);

            // Menambahkan kolom "ID Tiket" pada listview dengan lebar 100px dan rata tengah
            listTiket.Columns.Add("ID Tiket", 100, HorizontalAlignment.Center);

            // Menambahkan kolom "Nama Pelanggan" pada listview dengan lebar 150px dan rata tengah
            listTiket.Columns.Add("Nama Pelanggan", 150, HorizontalAlignment.Center);

            // Menambahkan kolom "Nama Bus" pada listview dengan lebar 150px dan rata tengah
            listTiket.Columns.Add("Nama Bus", 150, HorizontalAlignment.Center);

            // Menambahkan kolom "Rute" pada listview dengan lebar 130px dan rata tengah
            listTiket.Columns.Add("Rute", 130, HorizontalAlignment.Center);

            // Menambahkan kolom "Jumlah Tiket" pada listview dengan lebar 80px dan rata tengah
            listTiket.Columns.Add("Jumlah Tiket", 80, HorizontalAlignment.Center);

            // Menambahkan kolom "Tanggal Berangkat" pada listview dengan lebar 130px dan rata tengah
            listTiket.Columns.Add("Tanggal Berangkat", 130, HorizontalAlignment.Center);
        }

        // Event handler untuk tombol Cari
        private void btnCari_Click(object sender, EventArgs e)
        {
            // Membuat event ketika tombol "btnCari" diklik
            try
            {
                // Mengambil input dari text box "textIDPelanggan" dan mengkonversi ke integer
                int idPelanggan = Convert.ToInt32(textIDPelanggan.Text);

                // Mencari pelanggan berdasarkan ID yang dimasukkan
                tiket.Pelanggan = controllerPelanggan.ReadById(idPelanggan);
            }
            catch
            {
                // Menangkap error jika input ID pelanggan tidak valid
            }

            // Menampilkan nama pelanggan di text box "textNamaPelanggan" jika pelanggan ditemukan
            if (tiket.Pelanggan != null)
            {
                textNamaPelanggan.Text = tiket.Pelanggan.Nama;
            }

            // Menampilkan pesan jika pelanggan tidak ditemukan
            else
            {
                MessageBox.Show("Data Pelanggan tidak ditemukan", "Peringatan", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        // Event handler untuk tombol ID bus
        private void button1_Click(object sender, EventArgs e)
        {
            // Membuat event ketika tombol "button1_Click" diklik
           try
            {
                // Mengambil nilai dari textIDBus dan di-convert ke integer
                int idBus = Convert.ToInt32(textIDBus.Text);

                // Mencari bus berdasarkan ID yang dimasukkan
                tiket.Bus = controllerBus.ReadById(idBus);
            }
            catch
            {
                // Menangkap error jika input ID bus tidak valid
            }

            // Jika bus ditemuka
            if (tiket.Bus != null)
            {
                // Set nilai textNamaBus dengan nama bus yang ditemukan
                textNamaBus.Text = tiket.Bus.Nama;

                //set nilai textRute dengan rute bus yang ditemukan
                textRute.Text = tiket.Bus.Rute;

                // Memanggil Method
                CalcHargaTotal();
            }

            // Menampilkan pesan jika pelanggan tidak ditemukan
            else
            {
                MessageBox.Show("Data Bus tidak ditemukan", "Peringatan", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        // Event handler untuk tombol Order
        private void btnOrder_Click(object sender, EventArgs e)
        {
            // Mendapatkan input ID tiket dari textbox
            tiket.IDTiket = textIDTiket.Text;

            // Membuat event ketika tombol "btnOrder_Click" diklik
            try
            {
                tiket.JumlahTiket = Convert.ToInt32(textJumlahTiket.Text);
            }
            catch
            {
                // Menangkap error jika input ID tiket tidak valid
            }

            // Mendapatkan input keterangan dari textbox
            tiket.Keterangan = textKeterangan.Text;

            // Mendapatkan input tanggal berangkat dari datepicker
            tiket.TanggalBerangkat = dateBerangkat.Value;

            // Mendapatkan input tanggal pembelian tiket dari datepicker
            tiket.TanggalTiket = dateBeli.Value;

            // Memanggil method Create dari controller dengan parameter tiket yang telah diinputkan
            int result = controller.Create(tiket);

            // Jika hasil dari method Create lebih dari 0, maka akan menampilkan pesan berhasil order tiket
            if (result > 0)
            {
                MessageBox.Show("Behasil order tiket", "Peringatan", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

                // Memanggil method untuk memuat data kembali
                LoadData();

                // Memanggil method untuk mereset inputan
                Reset();
            }

            // Menampilkan pesan jika pelanggan tidak ditemukan
            else
            {
                MessageBox.Show("Gagal order tiket", "Peringatan", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        // Method yang digunakan untuk menghitung harga total dari tiket yang dipesan.
        private void CalcHargaTotal()
        {
            // Membuat event saat method CalcHargaTotal sedang dijalankan
            try
            {
                // Memastikan bahwa objek bus yang digunakan tidak null.
                if (tiket.Bus != null)

                    // Memastikan bahwa harga dari objek bus tidak sama dengan 0.
                    if (tiket.Bus.Harga != 0)

                        // Menghitung harga total dengan mengalikan harga dari objek bus dengan jumlah tiket yang dipesan, kemudian menampilkan hasilnya di textbox.
                        textHargaTotal.Text = (tiket.Bus.Harga * Convert.ToInt32(textJumlahTiket.Text)).ToString();

            }

            // Menangkap exception jika terjadi kesalahan.
            catch 
            {
                // Menampilkan nilai 0 di textbox jika terjadi kesalahan.
                textHargaTotal.Text = "0";
            }
        }

        // Input jumlah tiket
        private void textJumlahTiket_KeyUp(object sender, KeyEventArgs e)
        {
            // Memanggil Method
            CalcHargaTotal();
        }

        // Pilih data dari listview dan munculkan ke textbox
        private void listTiket_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mendapatkan index dari item yang dipilih dari listbox
            if (listTiket.SelectedIndices.Count>0)
            {
                // Mengambil objek tiket dari listOfTiket sesuai dengan index yang dipilih di listbox
                tiket = listOfTiket[listTiket.SelectedIndices[0]];

                // Menampilkan ID tiket pada textbox
                textIDTiket.Text = tiket.IDTiket;

                // Menampilkan tanggal pembelian tiket pada datepicker
                dateBeli.Value = tiket.TanggalTiket;

                // Menampilkan ID pelanggan pada textbox
                textIDPelanggan.Text = tiket.Pelanggan.IdPelanggan;

                // Menampilkan nama pelanggan pada textbox
                textNamaPelanggan.Text = tiket.Pelanggan.Nama;

                // Menampilkan ID bus pada textbox
                textIDBus.Text = tiket.Bus.IDBus;

                // Menampilkan nama bus pada textbox
                textNamaBus.Text = tiket.Bus.Nama;

                // Menampilkan rute bus pada textbox
                textRute.Text = tiket.Bus.Rute;

                // Menampilkan tanggal berangkat pada datepicker
                dateBerangkat.Value= tiket.TanggalBerangkat;

                // Menampilkan jumlah tiket pada textbox
                textJumlahTiket.Text = tiket.JumlahTiket.ToString();

                // Memanggil Method 
                CalcHargaTotal();

                //// Menampilkan keterangan pada textbox
                textKeterangan.Text = tiket.Keterangan;

                // Mengaktifkan tombol batal
                btnBatal.Enabled = true;
            }
        }

        // Event handler untuk tombol Batal
        private void btnBatal_Click(object sender, EventArgs e)
        {
            // Cek apakah ada data tiket yang dipilih
            if (listTiket.SelectedItems.Count > 0)
            {
                // Tampilkan konfirmasi ke user
                var konfirmasi = MessageBox.Show("Yakin ingin Hapus Data Tiket?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                // Jika user menekan tombol Yes
                if (konfirmasi == DialogResult.Yes)
                {
                    // Ambil data tiket yang mau dihapus dari collection
                    Tiket tiket = listOfTiket[listTiket.SelectedIndices[0]];

                    // Panggil operasi CRUD untuk menghapus data tiket
                    var result = controller.Delete(tiket);

                    // Cek apakah operasi berhasil
                    if (result > 0) LoadData();

                    // Reset form
                    Reset();
                }
            }

            // Jika tidak ada data yang dipilih, menampilkan pesan
            else
            {
                MessageBox.Show("Data Tiket belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        // Method Reset Form
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

            //Menempatkan fokus pada textIDTiket
            textIDTiket.Focus();

            //Menonaktifkan button Batal
            btnBatal.Enabled = false;
        }

        //Menjalankan method Reset ketika button Reset diklik
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Memanggil Method
            Reset();
        }
    }
}
