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
    public partial class FrmDataBus : Form
    {
      
        // deklarasi objek controller
        private BusController controller = new BusController();

        private List<Bus> listOfBus = new List<Bus>();

        public FrmDataBus()
        {
            InitializeComponent();

            // membuat objek controller
            controller = new BusController();

            InisialisasiListView();
            LoadDataBus();
            ResetForm();
        }

        private void InisialisasiListView()
        {
            lvwDataBus.View = System.Windows.Forms.View.Details;

            lvwDataBus.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwDataBus.Columns.Add("ID", 75, HorizontalAlignment.Center);
            lvwDataBus.Columns.Add("Nama", 200, HorizontalAlignment.Left);
            lvwDataBus.Columns.Add("Rute", 90, HorizontalAlignment.Center);
            lvwDataBus.Columns.Add("Harga", 90, HorizontalAlignment.Center);
        }

        // method untuk menampilkan semua data mahasiswa
        private void LoadDataBus()
        {
            // kosongkan listview
            listOfBus = controller.ReadAll();
            lvwDataBus.Items.Clear();

            // ekstrak objek mhs dari collection
            foreach (var bus in listOfBus)
            {
                var noUrut = lvwDataBus.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(bus.IDBus);
                item.SubItems.Add(bus.Nama);
                item.SubItems.Add(bus.Rute);
                item.SubItems.Add(bus.Harga.ToString());

                // tampilkan data mhs ke listview
                lvwDataBus.Items.Add(item);
            }
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek mahasiswa
            Bus bus = new Bus();

            // set nilai property objek mahasiswa yg diambil dari TextBox
            bus.IDBus = textIDBus.Text;
            bus.Nama = textNamaBus.Text;
            bus.Rute = textRuteBus.Text;
            try
            {
               bus.Harga = Convert.ToInt32(textHarga.Text);
            }
            catch
            {

            }
            

            int result = 0;

            // panggil operasi CRUD
            result = controller.Create(bus);

            if (result > 0) // tambah data berhasil
            {
                LoadDataBus();// panggil event OnCreate

                // reset form input, utk persiapan input data berikutnya

                btnReset.PerformClick();
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (lvwDataBus.SelectedItems.Count > 0)
            {
                Bus bus = new Bus();

                // set nilai property objek mahasiswa yg diambil dari TextBox
                bus.IDBus = textIDBus.Text;
                bus.Nama = textNamaBus.Text;
                bus.Rute = textRuteBus.Text;
                bus.Harga = Convert.ToInt32(textHarga.Text);

                int result = 0;

                // panggil operasi CRUD
                result = controller.Update(bus);

                if (result > 0) // tambah data berhasil
                {
                    LoadDataBus();// panggil event OnCreate

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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if(lvwDataBus.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Yakin ingin Hapus Data Bus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Bus bus = listOfBus[lvwDataBus.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(bus);
                    if (result > 0) LoadDataBus();

                    btnReset.PerformClick();
                }
            }

            else // data belum dipilih
            {
                MessageBox.Show("Data Bus belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lvwDataBus_MouseClick(object sender, MouseEventArgs e)
        {
            textIDBus.Text = lvwDataBus.SelectedItems[0].SubItems[1].Text;
            textIDBus.Enabled = false;
            textNamaBus.Text = lvwDataBus.SelectedItems[0].SubItems[2].Text;
            textRuteBus.Text = lvwDataBus.SelectedItems[0].SubItems[3].Text;
            textHarga.Text = lvwDataBus.SelectedItems[0].SubItems[4].Text;

            btnHapus.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void ResetForm()
        {

            textIDBus.Enabled = true;
            textIDBus.Clear();
            textNamaBus.Clear();
            textRuteBus.Clear();
            textHarga.Clear();

            textIDBus.Focus();
            btnHapus.Enabled = false;
            btnUpdate.Enabled = false;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
