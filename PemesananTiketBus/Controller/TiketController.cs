using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using PemesananTiketBus.Model.Context;
using PemesananTiketBus.Model.Entity;
using PemesananTiketBus.Model.Repository;

namespace PemesananTiketBus.Controller
{
    public class TiketController
    {
        private TiketRepository _repository;
        private bool Validate(Tiket tiket)
        {
            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(tiket.IDTiket))
            {
                MessageBox.Show("ID Tiket harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(tiket.Keterangan))
            {
                MessageBox.Show("Keterangan diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }



            if (tiket.JumlahTiket == 0)
            {
                MessageBox.Show("Jumlah tiket harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
        public int Create(Tiket tiket)
        {
            int result = 0;
            if (!Validate(tiket)) return 0;

            

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new TiketRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(tiket);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Tiket berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Tiket gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public int Update(Tiket tiket)
        {
            int result = 0;
            if (!Validate(tiket)) return 0;


            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new TiketRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.Update(tiket);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Tiket berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Tiket gagal diupdate !!!", "Peringatan",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }

        public int Delete(Tiket tiket)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(tiket.IDTiket))
            {
                MessageBox.Show("ID Tiket harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new TiketRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(tiket);
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
        public List<Tiket> ReadAll()
        {
            var items = new List<Tiket>();
            using (DbContext context = new DbContext())
            {
                _repository = new TiketRepository(context);
                items = _repository.ReadAll();
            }

            return items;
        }

        public Tiket ReadById(int ticketId)
        {
            Tiket item = null;
            using (DbContext context = new DbContext())
            {
                _repository = new TiketRepository(context);
                item = _repository.ReadById(ticketId);
            }
            return item;
        }
    }
}
