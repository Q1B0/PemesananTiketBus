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
        // deklarasi objek repository
        private BusRepository _repository;

        // method untuk membuat data
        public int Create(Bus bus)
        {
            int result = 0;

            // cek id yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bus.IDBus))
            {
                MessageBox.Show("ID Bus harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bus.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek rute yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bus.Rute))
            {
                MessageBox.Show("Rute harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            
            if (bus.Harga == 0)
            {
                MessageBox.Show("Harga harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new BusRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(bus);
            }

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
            return result;
        }

        // method untuk mengupdate data
        public int Update(Bus bus)
        {
            int result = 0;

            // cek id yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bus.IDBus))
            {
                MessageBox.Show("ID Bus harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bus.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek rute yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bus.Rute))
            {
                MessageBox.Show("Rute harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (bus.Harga == 0)
            {
                MessageBox.Show("Harga harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BusRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.Update(bus);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Bus berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Bus gagal diupdate !!!", "Peringatan",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        // method untuk menghapus data
        public int Delete(Bus bus)
        {
            int result = 0;

            // cek id yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(bus.IDBus))
            {
                MessageBox.Show("ID Bus harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BusRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(bus);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Bus berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Bus gagal dihapus !!!", "Peringatan",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        // method untuk menampilkan semua data
        public List<Bus> ReadAll()
        {
            var items = new List<Bus>();

            // membuat objek context menggunakan blok using
            using(DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BusRepository(context);

                // panggil method
                items = _repository.ReadAll();
            }

            return items;
        }

        // method untuk menampilkan data berdasarkan id
        public Bus ReadById(int idBus)
        {
            Bus item = null;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new BusRepository(context);

                // panggil method berdasarkan idBus
                item = _repository.ReadById(idBus);
            }

            return item;
        }

    }
}
