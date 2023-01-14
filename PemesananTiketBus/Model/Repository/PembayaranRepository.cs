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
    public class PembayaranRepository
    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public PembayaranRepository(DbContext context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public int Create(Pembayaran pembayaran)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into Pembayaran (idPembayaran, tglBayar, idTiket)
                           values (@idPembayaran, @tglBayar, @idTiket)";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idPembayaran", pembayaran.IDPembayaran);
                cmd.Parameters.AddWithValue("@tglBayar", pembayaran.TanggalBayar.ToString());
                cmd.Parameters.AddWithValue("@idTiket", pembayaran.Tiket.IDTiket);

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

        public List<Pembayaran> ReadAll()
        {
            var items = new List<Pembayaran>();
            // deklarasi perintah SQL
            string sql = @"select 
	idPembayaran, tglBayar,
	Tiket.idTiket, tglTiket, tglBerangkat,
	jumlah, keterangan, Tiket.idPelanggan, Tiket.idBus,
	Bus.nama nama_bus, rute,harga,
	Pelanggan.nama nama_pelanggan, alamat,email,no_tlp
	from Pembayaran
	join Tiket on Tiket.idTiket=Pembayaran.idTiket
	join Bus on Bus.idBus=Tiket.idBus
	join Pelanggan on Pelanggan.idPelanggan =Tiket.idPelanggan 
	order by tglBayar";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        var item = new Pembayaran()
                        {
                            IDPembayaran = dtr["idPembayaran"].ToString(),
                            TanggalBayar = DateTime.Parse(dtr["tglBayar"].ToString()),
                            Tiket = new Tiket()
                            {
                                IDTiket = dtr["idTiket"].ToString(),
                                TanggalTiket = DateTime.Parse(dtr["tglTiket"].ToString()),
                                TanggalBerangkat = DateTime.Parse(dtr["tglBerangkat"].ToString()),
                                JumlahTiket = Convert.ToInt32(dtr["jumlah"].ToString()),
                                Keterangan = dtr["keterangan"].ToString(),
                                Bus = new Bus()
                                {
                                    IDBus = dtr["idBus"].ToString(),
                                    Nama = dtr["nama_bus"].ToString(),
                                    Rute = dtr["rute"].ToString(),
                                    Harga = Convert.ToInt32(dtr["harga"].ToString()),
                                },
                                Pelanggan = new Pelanggan()
                                {
                                    IdPelanggan = dtr["idPelanggan"].ToString(),
                                    Nama = dtr["nama_pelanggan"].ToString(),
                                    Alamat = dtr["alamat"].ToString(),
                                    No_tlp = dtr["no_tlp"].ToString(),
                                    Email = dtr["email"].ToString(),
                                }
                            }
                        };
                        items.Add(item);
                    }
                }
            }

            return items;
        }
        // pengecualian, males
        public List<Pembayaran> ReadById(int idPembayaran)
        {
            var items = new List<Pembayaran>();
            // deklarasi perintah SQL
            string sql = @"select 
	idPembayaran, tglBayar,
	Tiket.idTiket, tglTiket, tglBerangkat,
	jumlah, keterangan, Tiket.idPelanggan, Tiket.idBus,
	Bus.nama nama_bus, rute,harga,
	Pelanggan.nama nama_pelanggan, alamat,email,no_tlp
	from Pembayaran
	join Tiket on Tiket.idTiket=Pembayaran.idTiket
	join Bus on Bus.idBus=Tiket.idBus
	join Pelanggan on Pelanggan.idPelanggan =Tiket.idPelanggan 
    where idPembayaran like @idPembayaran
	order by tglBayar";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@idPembayaran", idPembayaran);
                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        var item = new Pembayaran()
                        {
                            IDPembayaran = dtr["idPembayaran"].ToString(),
                            TanggalBayar = DateTime.Parse(dtr["tglBayar"].ToString()),
                            Tiket = new Tiket()
                            {
                                IDTiket = dtr["idTiket"].ToString(),
                                TanggalTiket = DateTime.Parse(dtr["tglTiket"].ToString()),
                                TanggalBerangkat = DateTime.Parse(dtr["tglBerangkat"].ToString()),
                                JumlahTiket = Convert.ToInt32(dtr["jumlah"].ToString()),
                                Keterangan = dtr["keterangan"].ToString(),
                                Bus = new Bus()
                                {
                                    IDBus = dtr["idBus"].ToString(),
                                    Nama = dtr["nama_bus"].ToString(),
                                    Rute = dtr["rute"].ToString(),
                                    Harga = Convert.ToInt32(dtr["harga"].ToString()),
                                },
                                Pelanggan = new Pelanggan()
                                {
                                    IdPelanggan = dtr["idPelanggan"].ToString(),
                                    Nama = dtr["nama_pelanggan"].ToString(),
                                    Alamat = dtr["alamat"].ToString(),
                                    No_tlp = dtr["no_tlp"].ToString(),
                                    Email = dtr["email"].ToString(),
                                }
                            }
                        };
                        items.Add(item);
                    }
                }
            }

            return items;
        }
        public List<Pembayaran> ReadByNama(string nama)
        {
            var items = new List<Pembayaran>();
            // deklarasi perintah SQL
            string sql = @"select 
	idPembayaran, tglBayar,
	Tiket.idTiket, tglTiket, tglBerangkat,
	jumlah, keterangan, Tiket.idPelanggan, Tiket.idBus,
	Bus.nama nama_bus, rute,harga,
	Pelanggan.nama nama_pelanggan, alamat,email,no_tlp
	from Pembayaran
	join Tiket on Tiket.idTiket=Pembayaran.idTiket
	join Bus on Bus.idBus=Tiket.idBus
	join Pelanggan on Pelanggan.idPelanggan =Tiket.idPelanggan 
    where Pelanggan.nama like @nama
	order by tglBayar";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", string.Format("%{0}%",nama));
                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        var item = new Pembayaran()
                        {
                            IDPembayaran = dtr["idPembayaran"].ToString(),
                            TanggalBayar = DateTime.Parse(dtr["tglBayar"].ToString()),
                            Tiket = new Tiket()
                            {
                                IDTiket = dtr["idTiket"].ToString(),
                                TanggalTiket = DateTime.Parse(dtr["tglTiket"].ToString()),
                                TanggalBerangkat = DateTime.Parse(dtr["tglBerangkat"].ToString()),
                                JumlahTiket = Convert.ToInt32(dtr["jumlah"].ToString()),
                                Keterangan = dtr["keterangan"].ToString(),
                                Bus = new Bus()
                                {
                                    IDBus = dtr["idBus"].ToString(),
                                    Nama = dtr["nama_bus"].ToString(),
                                    Rute = dtr["rute"].ToString(),
                                    Harga = Convert.ToInt32(dtr["harga"].ToString()),
                                },
                                Pelanggan = new Pelanggan()
                                {
                                    IdPelanggan = dtr["idPelanggan"].ToString(),
                                    Nama = dtr["nama_pelanggan"].ToString(),
                                    Alamat = dtr["alamat"].ToString(),
                                    No_tlp = dtr["no_tlp"].ToString(),
                                    Email = dtr["email"].ToString(),
                                }
                            }
                        };
                        items.Add(item);
                    }
                }
            }

            return items;
        }
    }
}
