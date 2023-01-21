using PemesananTiketBus.Model.Context;
using PemesananTiketBus.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PemesananTiketBus.Model.Repository;

namespace PemesananTiketBus.Controller
{
    public class BusController
    {
        // Deklarasi objek _repository sebagai objek dari kelas BusRepository
        private BusRepository _repository;

        // Method untuk menambah data bus baru
        public int Create(Bus bus)
        {
            int result = 0;

            // Validasi input ID bus
            if (string.IsNullOrEmpty(bus.IDBus))
            {
                MessageBox.Show("ID Bus harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi input nama bus
            if (string.IsNullOrEmpty(bus.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi input rute bus
            if (string.IsNullOrEmpty(bus.Rute))
            {
                MessageBox.Show("Rute harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            
            // Validasi input harga bus
            if (bus.Harga == 0)
            {
                MessageBox.Show("Harga harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Menggunakan blok using untuk membuat objek context dan repository
            using (DbContext context = new DbContext())
            {
                // Membuat objek repository
                _repository = new BusRepository(context);

                // Menambahkan data bus ke dalam database
                result = _repository.Create(bus);
            }

            //Menampilkan informasi hasil operasi
            if (result > 0)
            {
                MessageBox.Show("Data Bus berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Bus gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // Return hasil dari operasi create (berhasil atau tidak)
            return result;
        }

        // Method untuk mengupdate data bus
        public int Update(Bus bus)
        {
            int result = 0;

            // Validasi input ID bus
            if (string.IsNullOrEmpty(bus.IDBus))
            {
                MessageBox.Show("ID Bus harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi input nama bus
            if (string.IsNullOrEmpty(bus.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            //Validasi input rute bus
            if (string.IsNullOrEmpty(bus.Rute))
            {
                MessageBox.Show("Rute harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi input harga bus
            if (bus.Harga == 0)
            {
                MessageBox.Show("Harga harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Membuat objek baru dari kelas DbContext untuk digunakan dalam koneksi ke database
            using (DbContext context = new DbContext())
            {
                // Membuat objek baru dari kelas BusRepository dengan parameter 
                // context yang digunakan untuk koneksi ke database
                _repository = new BusRepository(context);

                // Menjalankan method update dari kelas BusRepository dengan parameter 
                // objek bus yang akan diupdate
                result = _repository.Update(bus);
            }

            // Jika proses update berhasil dilakukan
            if (result > 0)
            {
                // Menampilkan pesan informasi bahwa data bus berhasil diupdate
                MessageBox.Show("Data Bus berhasil diupdate !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Menampilkan pesan peringatan bahwa data bus gagal diupdate
                MessageBox.Show("Data Bus gagal diupdate !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // Return hasil dari operasi update (berhasil atau tidak)
            return result;
        }

        // Method untuk delet data bus
        public int Delete(Bus bus)
        {
            // Inisialisasi variabel result dengan nilai 0
            int result = 0;

            // Cek apakah IDBus yang akan dihapus kosong atau tidak
            if (string.IsNullOrEmpty(bus.IDBus))
            {
                // Jika IDBus kosong, menampilkan pesan peringatan
                MessageBox.Show("ID Bus harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Mengembalikan nilai 0
                return 0;
            }

            // Membuat objek baru dari kelas DbContext untuk digunakan dalam koneksi ke database
            using (DbContext context = new DbContext())
            {
                // Membuat objek baru dari kelas BusRepository dengan parameter 
                // context yang digunakan untuk koneksi ke database
                _repository = new BusRepository(context);

                // Menjalankan method delete dari kelas BusRepository dengan 
                // parameter objek bus yang akan dihapus
                result = _repository.Delete(bus);
            }

            // Jika proses delete berhasil dilakukan
            if (result > 0)
            {
                // Menampilkan pesan informasi bahwa data bus berhasil dihapus
                MessageBox.Show("Data Bus berhasil dihapus !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Menampilkan pesan peringatan bahwa data bus gagal dihapus
                MessageBox.Show("Data Bus gagal dihapus !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        public List<Bus> ReadAll()
        {
            var items = new List<Bus>();
            using(DbContext context = new DbContext())
            {
                _repository = new BusRepository(context);
                items = _repository.ReadAll();
            }

            // Mengembalikan nilai 0
            return items;
        }

        public Bus ReadById(int idBus)
        {
            // Inisialisasi objek item dengan nilai null
            Bus item = null;

            // Membuat objek baru dari kelas BusRepository dengan parameter 
            // context yang digunakan untuk koneksi ke database
            using (DbContext context = new DbContext())
            {
                // Membuat objek baru dari kelas BusRepository dengan parameter 
                // context yang digunakan untuk koneksi ke database
                _repository = new BusRepository(context);

                // Menjalankan method ReadById dari kelas BusRepository dengan parameter idBus yang akan dicari
                item = _repository.ReadById(idBus);
            }
            
            // Mengembalikan nilai 0
            return item;
        }

    }
}
