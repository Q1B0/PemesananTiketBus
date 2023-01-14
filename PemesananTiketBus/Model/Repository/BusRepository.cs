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
    public class BusRepository
    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public BusRepository(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(Bus bus)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into Bus (idBus, nama, rute, harga)
                           values (@idBus, @nama, @rute, @harga)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idBus", bus.IDBus);
                cmd.Parameters.AddWithValue("@nama", bus.Nama);
                cmd.Parameters.AddWithValue("@rute", bus.Rute);
                cmd.Parameters.AddWithValue("@harga", bus.Harga);

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

        public int Update(Bus bus)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update Bus set nama = @nama, rute = @rute, harga = @harga
                           where idBus = @idBus";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idBus", bus.IDBus);
                cmd.Parameters.AddWithValue("@nama", bus.Nama);
                cmd.Parameters.AddWithValue("@rute", bus.Rute);
                cmd.Parameters.AddWithValue("@harga", bus.Harga);

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

        public int Delete(Bus bus)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from Bus
                           where idBus = @idBus";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idBus", bus.IDBus);

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

        public List<Bus> ReadAll()
        {
            var items = new List<Bus>();
            // deklarasi perintah SQL
            string sql = @"select idBus, nama, rute, harga from Bus order by nama";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                using(SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while(dtr.Read())
                    {
                        var item = new Bus()
                        {
                            IDBus = dtr["idBus"].ToString(),
                            Harga = Convert.ToInt32(dtr["harga"].ToString()),
                            Nama = dtr["nama"].ToString(),
                            Rute = dtr["rute"].ToString()
                        };
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        public Bus ReadById(int idBus)
        {
            Bus item = null;
            // deklarasi perintah SQL
            string sql = @"select idBus, nama, rute, harga from Bus  where idBus = @idBus order by nama";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@idBus", idBus);
                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {

                        item = new Bus();
                        item.IDBus = dtr["idBus"].ToString();
                        item.Harga = Convert.ToInt32(dtr["harga"].ToString());
                        item.Nama = dtr["nama"].ToString();
                        item.Rute = dtr["rute"].ToString();
                      
                    }
                }
            }

            return item;
        }

    }
}
