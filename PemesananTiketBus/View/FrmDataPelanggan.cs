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
        // deklarasi objek controller
        private PelangganController controller = new PelangganController();

        private List<Pelanggan> listOfPelanggan = new List<Pelanggan>();

        private Pelanggan pelanggan = new Pelanggan();

        public FrmDataPelanggan()
        {
            InitializeComponent();
            InisialisasiListView();
            LoadDataPelanggan();
            ResetForm();
        }

        private void InisialisasiListView()
        {
            listDataPelanggan.View = System.Windows.Forms.View.Details;
            listDataPelanggan.FullRowSelect = true;
            listDataPelanggan.GridLines = true;

            listDataPelanggan.Columns.Add("No.", 30, HorizontalAlignment.Center);
            listDataPelanggan.Columns.Add("ID", 60, HorizontalAlignment.Center);
            listDataPelanggan.Columns.Add("Nama", 150, HorizontalAlignment.Center);
            listDataPelanggan.Columns.Add("No_Tlp", 90, HorizontalAlignment.Center);
            listDataPelanggan.Columns.Add("Alamat", 100, HorizontalAlignment.Center);
            listDataPelanggan.Columns.Add("Email", 135, HorizontalAlignment.Center);
        }

        // method untuk menampilkan semua data mahasiswa
        private void LoadDataPelanggan()
        {
            // kosongkan listview
            listOfPelanggan = controller.ReadAll();
            listDataPelanggan.Items.Clear();

            // ekstrak objek mhs dari collection
            foreach (var pelanggan in listOfPelanggan)
            {
                var noUrut = listDataPelanggan.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(pelanggan.IdPelanggan);
                item.SubItems.Add(pelanggan.Nama);
                item.SubItems.Add(pelanggan.No_tlp);
                item.SubItems.Add(pelanggan.Alamat);
                item.SubItems.Add(pelanggan.Email);

                // tampilkan data mhs ke listview
                listDataPelanggan.Items.Add(item);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // set nilai property objek mahasiswa yg diambil dari TextBox
            pelanggan.IdPelanggan = textIDPelanggan.Text;
            pelanggan.Nama = textNama.Text;
            pelanggan.No_tlp = textNoTelp.Text;
            pelanggan.Alamat = textAlamat.Text;
            pelanggan.Email = textEmail.Text;

            int result = 0;

            // panggil operasi CRUD
            result = controller.Create(pelanggan);

            if (result > 0) // tambah data berhasil
            {
                LoadDataPelanggan();// panggil event OnCreate

                // reset form input, utk persiapan input data berikutnya

                btnReset.PerformClick();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listDataPelanggan.SelectedItems.Count > 0)
            {
                // set nilai property objek mahasiswa yg diambil dari TextBox
                pelanggan.IdPelanggan = textIDPelanggan.Text;
                pelanggan.Nama = textNama.Text;
                pelanggan.No_tlp = textNoTelp.Text;
                pelanggan.Alamat = textAlamat.Text;
                pelanggan.Email = textEmail.Text;

                int result = 0;

                // panggil operasi CRUD
                result = controller.Update(pelanggan);

                if (result > 0) // tambah data berhasil
                {
                    LoadDataPelanggan();// panggil event OnCreate

                    // reset form input, utk persiapan input data berikutnya

                    btnReset.PerformClick();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listDataPelanggan.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Yakin ingin Hapus Data Pelanggan?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Pelanggan pelanggan = listOfPelanggan[listDataPelanggan.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(pelanggan);
                    if (result > 0) LoadDataPelanggan();

                    btnReset.PerformClick();
                }
            }

            else // data belum dipilih
            {
                MessageBox.Show("Data Pelanggan belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void listDataPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDataPelanggan.SelectedIndices.Count > 0)
            {
                pelanggan = listOfPelanggan[listDataPelanggan.SelectedIndices[0]];
                textIDPelanggan.Text = pelanggan.IdPelanggan;
                textIDPelanggan.Enabled = false;
                textNama.Text = pelanggan.Nama;
                textNoTelp.Text = pelanggan.No_tlp;
                textAlamat.Text = pelanggan.Alamat;
                textEmail.Text = pelanggan.Email;

                btnDelete.Enabled = true; // enable button Hapus saat data dalam listview dipilih
                btnUpdate.Enabled = true; // enable button Update saat data dalam listview dipilih
            }
        }

        private void ResetForm()
        {
            textIDPelanggan.Clear();
            textIDPelanggan.Enabled = true;
            textNama.Clear();
            textNoTelp.Clear();
            textAlamat.Clear();
            textEmail.Clear();

            textIDPelanggan.Focus();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
