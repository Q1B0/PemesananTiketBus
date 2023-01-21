using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PemesananTiketBus.Model.Repository;
using PemesananTiketBus.Model.Context;
using PemesananTiketBus.Model.Entity;

namespace PemesananTiketBus.Controller
{
    public class PembayaranController
    {
        // deklarasi objek repository
        private PembayaranRepository _repository;

        // method untuk cek input data
        private bool Validate(Pembayaran pembayaran)
        {
            // cek id yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pembayaran.IDPembayaran))
            {
                MessageBox.Show("ID Pembayaran harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // cek tanggal bayar yang diinputkan tidak boleh kosong
            if (pembayaran.TanggalBayar == null)
            {
                MessageBox.Show("Tanggal harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        // method untuk membuat data
        public int Create(Pembayaran pembayaran)
        {
            int result = 0;

            // panggil method untuk pengecekan
            if (!Validate(pembayaran)) return 0;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new PembayaranRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(pembayaran);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Pembayaran berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Pembayaran gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        // method untuk menghapus data
        public int Delete(Pembayaran pembayaran)
        {
            int result = 0;

            // cek id Pembayaran yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(pembayaran.IDPembayaran))
            {
                MessageBox.Show("ID Pembayaran harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PembayaranRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(pembayaran);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Tiket berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Tiket gagal dihapus !!!", "Peringatan",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        // method untuk menampilkan semua data
        public List<Pembayaran> ReadAll()
        {
            var items = new List<Pembayaran>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PembayaranRepository(context);

                // panggil method
                items = _repository.ReadAll();
            }

            return items;
        }

        // method untuk menampilkan data berdasarkan id
        public List<Pembayaran> ReadById(int idPembayaran)
        {
            var items = new List<Pembayaran>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PembayaranRepository(context);

                // panggil method berdasarkan idPembayaran
                items = _repository.ReadById(idPembayaran);
            }

            return items;
        }

        // method untuk menampilkan data berdasarkan nama pelanggan
        public List<Pembayaran> ReadByNama(string nama)
        {
            var items = new List<Pembayaran>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new PembayaranRepository(context);

                // panggil method berdasarkan nama pelanggan
                items = _repository.ReadByNama(nama);
            }

            return items;
        }
    }
}
