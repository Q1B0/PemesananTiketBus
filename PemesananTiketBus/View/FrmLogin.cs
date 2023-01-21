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

namespace PemesananTiketBus.View
{
    public partial class FrmLogin : Form
    {
        // Membuat method constructor yang digunakan untuk menginisialisasi komponen
        public FrmLogin()
        {
            // Method unntuk menginisialisasi seluruh komponen 
            InitializeComponent();

            // Menampilkan teks "admin" pada textbox dengan ID textUserID
            textUserID.Text = "admin";

            // Menampilkan teks "admin" pada textbox dengan ID textPassword
            textPassword.Text = "admin";
        }

        // Method ini akan dijalankan ketika tombol dengan ID btnLogin diklik
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            // Membuat objek baru dari class UserController
            UserController controller = new UserController();

            // Memanggil method IsValidUser dari objek controller dengan parameter 
            // userID dan password yang diambil dari textbox
            bool isValidUser = controller.IsValidUser(textUserID.Text, textPassword.Text);

            // Jika user yang dimasukkan valid
            if (isValidUser)
            {
                // Menetapkan nilai DialogResult sebagai OK
                // DialogResult akan digunakan untuk mengecek apakah proses login berhasil atau tidak
                this.DialogResult = DialogResult.OK;

                // Menutup form
                this.Close();
            }
        }
    }
}
