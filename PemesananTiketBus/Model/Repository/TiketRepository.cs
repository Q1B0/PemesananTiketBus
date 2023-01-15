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
	public class TiketRepository
	{

		// deklarsi objek connection
		private SQLiteConnection _conn;

		// constructor
		public TiketRepository(DbContext context)
		{
			// inisialisasi objek connection
			_conn = context.Conn;
		}

		public int Create(Tiket tiket)
		{
			int result = 0;

			// deklarasi perintah SQL
			string sql = @"insert into Tiket (idTiket, tglTiket, tglBerangkat, jumlah, keterangan, idPelanggan, idBus)
						   values (@idTiket, @tglTiket, @tglBerangkat, @jumlah, @keterangan, @idPelanggan, @idBus)";

			// membuat objek command menggunakan blok using
			using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
			{
				// mendaftarkan parameter dan mengeset nilainya
				cmd.Parameters.AddWithValue("@idTiket", tiket.IDTiket);
				cmd.Parameters.AddWithValue("@tglTiket", tiket.TanggalTiket.ToString());
				cmd.Parameters.AddWithValue("@tglBerangkat", tiket.TanggalBerangkat.ToString());
				cmd.Parameters.AddWithValue("@jumlah", tiket.JumlahTiket);
				cmd.Parameters.AddWithValue("@keterangan", tiket.Keterangan);
				cmd.Parameters.AddWithValue("@idPelanggan", tiket.Pelanggan.IdPelanggan);
				cmd.Parameters.AddWithValue("@idBus", tiket.Bus.IDBus);

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

		public int Update(Tiket tiket)
		{
			int result = 0;

			// deklarasi perintah SQL
			string sql = @"update Tiket set tglTiket = @tglTiket, tglBerangkat = @tglBerangkat, jumlah = @jumlah, keterangan = @keterangan
						   where idTiket = @idTiket";

			// membuat objek command menggunakan blok using
			using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
			{
				// mendaftarkan parameter dan mengeset nilainya
				cmd.Parameters.AddWithValue("@idTiket", tiket.IDTiket);
				cmd.Parameters.AddWithValue("@tglTiket", tiket.TanggalTiket.ToString());
				cmd.Parameters.AddWithValue("@tglBerangkat", tiket.TanggalBerangkat.ToString());
				cmd.Parameters.AddWithValue("@jumlah", tiket.JumlahTiket);
				cmd.Parameters.AddWithValue("@keterangan", tiket.Keterangan);

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

		public int Delete(Tiket tiket)
		{
			int result = 0;

			// deklarasi perintah SQL
			string sql = @"delete from Tiket
						   where idTiket = @idTiket";

			// membuat objek command menggunakan blok using
			using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
			{
				// mendaftarkan parameter dan mengeset nilainya
				cmd.Parameters.AddWithValue("@idTiket", tiket.IDTiket);

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

		public List<Tiket> ReadAll()
		{
			var items = new List<Tiket>();
			// deklarasi perintah SQL
			string sql = @"select
		idTiket, tglTiket, tglBerangkat, jumlah, keterangan, Tiket.idPelanggan, Tiket.idBus,
		Bus.nama nama_bus, rute,harga,
		Pelanggan.nama nama_pelanggan, alamat,email,no_tlp
		from Tiket
		join Bus on Bus.idBus=Tiket.idBus
		join Pelanggan on Pelanggan.idPelanggan =Tiket.idPelanggan 
		order by tglBerangkat";

			// membuat objek command menggunakan blok using
			using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
			{
				using (SQLiteDataReader dtr = cmd.ExecuteReader())
				{
					while (dtr.Read())
					{
						var item = new Tiket()
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
						};
						items.Add(item);
					}
				}
			}

			return items;
		}

		public Tiket ReadById(int IdTiket)
		{

			Tiket item = null;
			// deklarasi perintah SQL
			string sql = @"select
		idTiket, tglTiket, tglBerangkat, jumlah, keterangan, Tiket.idPelanggan, Tiket.idBus,
		Bus.nama nama_bus, rute,harga,
		Pelanggan.nama nama_pelanggan, alamat,email,no_tlp
		from Tiket
		join Bus on Bus.idBus=Tiket.idBus
		join Pelanggan on Pelanggan.idPelanggan =Tiket.idPelanggan 
		where idTiket=@idTiket";

			// membuat objek command menggunakan blok using
			using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
			{
				cmd.Parameters.AddWithValue("@idTiket", IdTiket);
				using (SQLiteDataReader dtr = cmd.ExecuteReader())
				{
					while (dtr.Read())
					{
						item = new Tiket()
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
						};
					}
				}
			}

			return item;
		}
	}
}
