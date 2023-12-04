using Npgsql;
using NpgsqlTypes;
using PBOB2_2023.App.Core;
using PBOB2_2023.App.Model;
using System.Data;

namespace PBOB2_2023.App.Context
{
    internal class PenjadwalanSemproContext : DatabaseWrapper
    {
        private static string table = "penjadwalan_sempro";

        public static DataTable all()
        {
            string query = $@"SELECT * FROM {table} ORDER BY id_jadwal_sempro";
            DataTable dataPenjadwalanSempro = queryExecutor(query);
            return dataPenjadwalanSempro;
        }

        public static DataTable show(int id_jadwal_sempro)
        {
            string query = $"SELECT * FROM {table} WHERE id_jadwal_sempro = @id_jadwal_sempro";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sempro", NpgsqlDbType.Integer){Value = id_jadwal_sempro},
            };
            DataTable dataPengajuanSempro = queryExecutor(query, parameters);
            return dataPengajuanSempro;
        }

        public static void store(M_PenjadwalanSempro penjadwalanSemproBaru)
        {
            string query = $"INSERT INTO {table} (nama_mahasiswa, nim, prodi, tanggal, jam, judul, link_zoom, br_zoom, pembimbing1, pembimbing2, penguji1, penguji2, status) VALUES(@nama_mahasiswa, @nim, @prodi, @tanggal, @jam, @judul, @link_zoom, @br_zoom, @pembimbing1, @pembimbing2, @penguji1, @penguji2, @status)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama_mahasiswa", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.nama_mahasiswa},
                new NpgsqlParameter("@nim", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.nim},
                new NpgsqlParameter("@prodi", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.prodi},
                new NpgsqlParameter("@tanggal", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.tanggal},
                new NpgsqlParameter("@jam", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.jam},
                new NpgsqlParameter("@judul", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.judul},
                new NpgsqlParameter("@link_zoom", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.link_zoom},
                new NpgsqlParameter("@br_zoom", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.br_zoom},
                new NpgsqlParameter("@pembimbing1", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.pembimbing1},
                new NpgsqlParameter("@pembimbing2", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.pembimbing2},
                new NpgsqlParameter("@penguji1", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.penguji1},
                new NpgsqlParameter("@penguji2", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.penguji2},
                new NpgsqlParameter("@no_telepon", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.no_telepon},
                new NpgsqlParameter("@status", NpgsqlDbType.Varchar){Value = penjadwalanSemproBaru.status}
            };
            commandExecutor(query, parameters);
        }

        public static void destroy(int id_jadwal_sempro)
        {
            string query = $"DELETE FROM {table} WHERE id_jadwal_sempro = @id_jadwal_sempro";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sempro", NpgsqlDbType.Integer){Value = id_jadwal_sempro},
            };
            commandExecutor(query, parameters);
        }

        public static void update(M_PenjadwalanSempro penjadwalanSemproEdit)
        {
            string query = $"UPDATE {table} SET id_jadwal_sempro = @id_jadwal_sempro, nama_mahasiswa = @nama_mahasiswa, nim = @nama, prodi = @prodi, tanggal = @tanggal, jam = @jam, judul = @judul, link_zoom = @link_zoom, br_zoom = @br_zoom, pembimbing1 = @pembimbing1, pembimbing2 = @pembimbing2, penguji1 = @penguji1, penguji2 = @penguji2, status = @status WHERE id_jadwal_sempro = @id_jadwal_sempro";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sempro", NpgsqlDbType.Integer){Value = penjadwalanSemproEdit.id_jadwal_sempro},
                new NpgsqlParameter("@nama_mahasiswa", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.nama_mahasiswa},
                new NpgsqlParameter("@nim", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.nim},
                new NpgsqlParameter("@prodi", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.prodi},
                new NpgsqlParameter("@tanggal", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.tanggal},
                new NpgsqlParameter("@jam", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.jam},
                new NpgsqlParameter("@judul", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.judul},
                new NpgsqlParameter("@link_zoom", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.link_zoom},
                new NpgsqlParameter("@br_zoom", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.br_zoom},
                new NpgsqlParameter("@pembimbing1", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.pembimbing1},
                new NpgsqlParameter("@pembimbing2", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.pembimbing2},
                new NpgsqlParameter("@penguji1", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.penguji1},
                new NpgsqlParameter("@penguji2", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.penguji2},
                new NpgsqlParameter("@no_telepon", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.no_telepon},
                new NpgsqlParameter("@status", NpgsqlDbType.Varchar){Value = penjadwalanSemproEdit.no_telepon}
            };
            commandExecutor(query, parameters);
        }
        public static void ubahJadwal(int id_jadwal_sempro, string nama_mahasiswa, string nim, string jam, string tanggal, string judul, string no_telepon, string pembimbing1, string pembimbing2, string prodi)
        {
            string query = $"UPDATE {table} SET nama_mahasiswa = '{nama_mahasiswa}', nim = '{nim}', jam = '{jam}', tanggal = '{tanggal}', judul = '{judul}', no_telepon = '{no_telepon}', pembimbing1 = '{pembimbing1}', pembimbing2 = '{pembimbing2}', prodi = '{prodi}' WHERE id_jadwal_sempro = {id_jadwal_sempro};";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_aktivitas", NpgsqlDbType.Integer){Value = id_jadwal_sempro}
            };
            commandExecutor(query, parameters);
        }

        public static void updateKombi(int id_jadwal_sempro, string penguji1, string penguji2)
        {
            string query = $"UPDATE {table} SET penguji1 = '{penguji1}', penguji2 = '{penguji2}' WHERE id_jadwal_sempro = '{id_jadwal_sempro}'";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sempro", NpgsqlDbType.Integer){Value = id_jadwal_sempro}
            };
            commandExecutor(query, parameters);
        }

        public static void ubahStatus(int id_jadwal_sempro, string status)
        {
            string query = $"UPDATE {table} SET status = '{status}' WHERE id_jadwal_sempro = '{id_jadwal_sempro}';";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sempro", NpgsqlDbType.Integer){Value = id_jadwal_sempro}
            };
            commandExecutor(query, parameters);
        }

        public static void ubahJadwal2(int id_jadwal_sempro, string link_zoom, string br_zoom)
        {
            string query = $"UPDATE {table} SET link_zoom = '{link_zoom}', br_zoom = '{br_zoom}' WHERE id_jadwal_sempro = '{id_jadwal_sempro}'";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sempro", NpgsqlDbType.Integer){Value = id_jadwal_sempro}
            };
            commandExecutor(query, parameters);
        }
        public static DataTable viewJadwal()
        {
            string query = $@"SELECT id_jadwal_sempro, nama_mahasiswa, nim, prodi, tanggal, jam, judul, link_zoom, br_zoom, pembimbing1, pembimbing2, penguji1, penguji2 FROM {table} ORDER BY id_jadwal_sempro";
            DataTable dataPenjadwalanSempro = queryExecutor(query);
            return dataPenjadwalanSempro;
        }
    }
}
