using Npgsql;
using NpgsqlTypes;
using PBOB2_2023.App.Core;
using PBOB2_2023.App.Model;
using System.Data;

namespace PBOB2_2023.App.Context
{
    internal class PenjadwalanSidangSkripsiContext : DatabaseWrapper
    {
        private static string table = "penjadwalan_sidang_skripsi";


        public static DataTable all()
        {
            string query = $"SELECT * from {table} ORDER BY id_jadwal_sidang";
            DataTable dataPengajuanSemproAll = queryExecutor(query);
            return dataPengajuanSemproAll;
        }

        public static DataTable show(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id_jadwal_sidang = @id_jadwal_sidang";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sidang", NpgsqlDbType.Integer){Value = id},
            };
            DataTable penjadwalanSidangSkripsi = queryExecutor(query, parameters);
            return penjadwalanSidangSkripsi;
        }

        public static void store(M_PenjadwalanSidangSkripsi PenjadwalanSidangSkripsiBaru)
        {
            string query = $"INSERT INTO {table}(nama_mahasiswa, nim, prodi, tanggal, jam, ruang, judul, pembimbing1, pembimbing2, penguji1, penguji2, status) VALUES( @nama_mahasiswa, @nim, @prodi, @tanggal, @jam, @ruang, @judul, @pembimbing1, @pembimbing2, @penguji1, @penguji2, @status)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama_mahasiswa", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.nama_mahasiswa },
                new NpgsqlParameter("@nim", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.nim },
                new NpgsqlParameter("@prodi", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.prodi },
                new NpgsqlParameter("@tanggal", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.tanggal },
                new NpgsqlParameter("@jam", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.jam },
                new NpgsqlParameter("@ruang", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.ruang },
                new NpgsqlParameter("@judul", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.judul },
                new NpgsqlParameter("@pembimbing1", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.pembimbing1 },
                new NpgsqlParameter("@pembimbing2", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.pembimbing2 },
                new NpgsqlParameter("@penguji1", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.penguji1 },
                new NpgsqlParameter("@penguji2", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.penguji2 },
                new NpgsqlParameter("@status", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiBaru.status },

            };
            commandExecutor(query, parameters);
        }

        public static void destroy(int id)
        {
            string query = $"DELETE FROM {table} WHERE id = @id_jadwal_sidang";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sidang", NpgsqlDbType.Integer){Value = id},
            };
            commandExecutor(query, parameters);
        }

        public static void update(M_PenjadwalanSidangSkripsi PenjadwalanSidangSkripsiEdit)
        {
            string query = $"UPDATE {table} SET nama_mahasiswa = @nama_mahasiswa, nim = @nim, prodi = @prodi, tanggal = @tanggal, jam = @jam, ruang = @ruang, judul = @judul, pembimbing1 = @pembimbing1, pembimbing2 = @pembimbing2, penguji1 = @penguji1, penguji2 = @penguji2 WHERE id_jadwal_sidang = @id_jadwal_sidang";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama_mahasiswa", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.nama_mahasiswa },
                new NpgsqlParameter("@nim", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.nim },
                new NpgsqlParameter("@prodi", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.prodi },
                new NpgsqlParameter("@tanggal", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.tanggal },
                new NpgsqlParameter("@jam", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.jam },
                new NpgsqlParameter("@ruang", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.ruang },
                new NpgsqlParameter("@judul", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.judul },
                new NpgsqlParameter("@pembimbing1", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.pembimbing1 },
                new NpgsqlParameter("@pembimbing2", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.pembimbing2 },
                new NpgsqlParameter("@penguji1", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.penguji1 },
                new NpgsqlParameter("@penguji2", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.penguji2 },
                new NpgsqlParameter("@id_jadwal_sidang", NpgsqlDbType.Varchar) { Value = PenjadwalanSidangSkripsiEdit.id_jadwal_sidang },
            };
            commandExecutor(query, parameters);
        }

        public static void ubahStatus(int id_jadwal_sidang, string status)
        {
            string query = $"UPDATE {table} SET status = '{status}' WHERE id_jadwal_sidang = '{id_jadwal_sidang}';";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sidang", NpgsqlDbType.Integer){Value = id_jadwal_sidang}
    };
            commandExecutor(query, parameters);
        }

        public static void ubahJadwal(int id_jadwal_sidang, string nama_mahasiswa, string nim, string prodi, string tanggal, string jam, string judul, string ruang, string pembimbing1, string pembimbing2)
        {
            string query = $"UPDATE {table} SET nama_mahasiswa = '{nama_mahasiswa}', nim = '{nim}',  prodi = '{prodi}', tanggal = '{tanggal}', jam = '{jam}', judul = '{judul}', ruang = '{ruang}', pembimbing1 = '{pembimbing1}', pembimbing2 = '{pembimbing2}' WHERE id_jadwal_sidang = {id_jadwal_sidang};";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sidang", NpgsqlDbType.Integer) { Value = id_jadwal_sidang }
            };
            commandExecutor(query, parameters);

        }

        public static void updateKombi(int id_jadwal_sidang, string penguji1, string penguji2)
        {
            string query = $"UPDATE {table} SET penguji1 = '{penguji1}', penguji2 = '{penguji2}' WHERE id_jadwal_sidang = '{id_jadwal_sidang}'";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sidang", NpgsqlDbType.Integer){Value = id_jadwal_sidang}
            };
            commandExecutor(query, parameters);
        }

        public static DataTable ArsipJudul(string status)
        {
            string query = $"SELECT nama_mahasiswa, nim, prodi, judul, pembimbing1, pembimbing2, penguji1, penguji2 from {table} WHERE status = '{status}' ORDER BY id_jadwal_sidang";
            DataTable dataArsipJudul = queryExecutor(query);
            return dataArsipJudul;
        }
        public static DataTable Search(string keyword)
        {
            string query = $"SELECT * FROM {table} WHERE nama_mahasiswa ILIKE '%{keyword}%' OR nim ILIKE '%{keyword}%' OR judul ILIKE '%{keyword}%' OR pembimbing1 ILIKE '%{keyword}%' OR pembimbing2 ILIKE '%{keyword}%' OR penguji1 ILIKE '%{keyword}%' OR penguji2 ILIKE '%{keyword}%'";
            DataTable searchData = queryExecutor(query);
            return searchData;
        }
        public static DataTable viewJadwalSidang()
        {
            string query = $"SELECT id_jadwal_sidang, nama_mahasiswa, nim, prodi, tanggal, jam, judul, ruang, pembimbing1, pembimbing2, penguji1, penguji2 from {table} ORDER BY id_jadwal_sidang";
            DataTable dataPengajuanSemproAll = queryExecutor(query);
            return dataPengajuanSemproAll;
        }
    }
}