using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using PemesananTiketBus.Model.Context;
using PemesananTiketBus.Model.Repository;
using System.Windows.Forms;

namespace PemesananTiketBus.Controller
{
    public class UserController
    {
        // deklarasi objek Repository untuk menjalankan operasi CRUD
        private UserRepository _repository;

        public bool IsValidUser(string userName, string password)
        {
            // cek username yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("User name harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // cek password yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            bool isValidUser = false;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new UserRepository(context);

                // panggil method IsValidUser class repository untuk mengecek apakah user dan password benar
                isValidUser = _repository.IsValidUser(userName, password);
            }

            if (!isValidUser)
            {
                MessageBox.Show("User name atau password salah !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
    }
}
