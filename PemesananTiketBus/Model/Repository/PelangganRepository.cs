using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PemesananTiketBus.Model.Entity;
using PemesananTiketBus.Model.Context;
using System.Data.SQLite;

namespace PemesananTiketBus.Model.Repository
{
    public class PelangganRepository
    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public PelangganRepository(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(Pelanggan pelanggan)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into Pelanggan (idPelanggan, nama, no_tlp, alamat, email)
                           values (@idPelanggan, @nama, @no_tlp, @alamat, @email)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idPelanggan", pelanggan.IdPelanggan);
                cmd.Parameters.AddWithValue("@nama", pelanggan.Nama);
                cmd.Parameters.AddWithValue("@no_tlp", pelanggan.No_tlp);
                cmd.Parameters.AddWithValue("@alamat", pelanggan.Alamat);
                cmd.Parameters.AddWithValue("@email", pelanggan.Email);

                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Update(Pelanggan pelanggan)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update Pelanggan set nama = @nama, no_tlp = @no_tlp, alamat = @alamat, email = @email
                           where idPelanggan = @idPelanggan";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idPelanggan", pelanggan.IdPelanggan);
                cmd.Parameters.AddWithValue("@nama", pelanggan.Nama);
                cmd.Parameters.AddWithValue("@no_tlp", pelanggan.No_tlp);
                cmd.Parameters.AddWithValue("@alamat", pelanggan.Alamat);
                cmd.Parameters.AddWithValue("@email", pelanggan.Email);

                try
                {
                    // jalankan perintah UPDATE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Delete(Pelanggan pelanggan)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from Pelanggan
                           where idPelanggan = @idPelanggan";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idPelanggan", pelanggan.IdPelanggan);

                try
                {
                    // jalankan perintah DELETE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result;
        }

        public List<Pelanggan> ReadAll()
        {
            var items = new List<Pelanggan>();
            // deklarasi perintah SQL
            string sql = @"select idPelanggan, nama, no_tlp, alamat, email from Pelanggan order by idPelanggan";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        var item = new Pelanggan()
                        {
                            IdPelanggan = dtr["idPelanggan"].ToString(),
                            No_tlp = dtr["no_tlp"].ToString(),
                            Nama = dtr["nama"].ToString(),
                            Alamat = dtr["alamat"].ToString(),
                            Email = dtr["email"].ToString()
                        };
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        public Pelanggan ReadById(int idPelanggan)
        {
            Pelanggan item = null;
            // deklarasi perintah SQL
            string sql = @"select idPelanggan, nama, no_tlp, alamat, email from Pelanggan where idPelanggan=@idPelanggan order by nama ";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@idPelanggan", idPelanggan);
                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        item = new Pelanggan();
                        item.IdPelanggan = dtr["idPelanggan"].ToString();
                        item.No_tlp = dtr["no_tlp"].ToString();
                        item.Nama = dtr["nama"].ToString();
                        item.Alamat = dtr["alamat"].ToString();
                        item.Email = dtr["email"].ToString();
                        
                    }
                }
            }

            return item;
        }

    }
}
