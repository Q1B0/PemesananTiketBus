using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PemesananTiketBus.Model.Context;
using PemesananTiketBus.Model.Entity;
using System.Windows.Forms;
using PemesananTiketBus.Model.Repository;

namespace PemesananTiketBus.Controller
{
    public class PelangganController
    {
        // deklarasi objek repository
        private PelangganRepository _repository;

        // method untuk membuat data
        public int Create(Pelanggan pelanggan)
        {
            int result = 0;

            // cek id yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pelanggan.IdPelanggan))
            {
                MessageBox.Show("ID Pelanggan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pelanggan.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nomor telepon yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pelanggan.No_tlp))
            {
                MessageBox.Show("Nomor Telepon harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek alamat yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pelanggan.Alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new PelangganRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(pelanggan);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Pelanggan berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Pelanggan gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        // method untuk mengupdate data
        public int Update(Pelanggan pelanggan)
        {
            int result = 0;

            // cek id yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pelanggan.IdPelanggan))
            {
                MessageBox.Show("ID Pelanggan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pelanggan.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nomor telepon yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pelanggan.No_tlp))
            {
                MessageBox.Show("Nomor Telepon harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek alamat yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pelanggan.Alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.Update(pelanggan);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Pelanggan berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Pelanggan gagal diupdate !!!", "Peringatan",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        // method untuk menghapus data
        public int Delete(Pelanggan pelanggan)
        {
            int result = 0;

            // cek id yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pelanggan.IdPelanggan))
            {
                MessageBox.Show("ID Pelanggan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(pelanggan);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Pelanggan berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Pelanggan gagal dihapus !!!", "Peringatan",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        // method untuk menampilkan semua data
        public List<Pelanggan> ReadAll()
        {
            var items = new List<Pelanggan>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method
                items = _repository.ReadAll();
            }

            return items;
        }

        // method untuk menampilkan data berdasarkan id
        public Pelanggan ReadById(int idPelanggan)
        {
            Pelanggan item = null;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PelangganRepository(context);

                // panggil method berdasarkan idPelanggan
                item = _repository.ReadById(idPelanggan);
            }

            return item;
        }
    }
}
