using Npgsql;
using NpgsqlTypes;
using PBOB2_2023.App.Core;
using PBOB2_2023.App.Model;
using System.Data;
namespace PBOB2_2023.App.Context
{
    internal class PengajuanSemproContext : DatabaseWrapper
    {
        private static string table = "pengajuan_sempro";

        public static DataTable all()
        {
            string query = $@"SELECT * FROM {table}";
            DataTable dataPengajuanSempro = queryExecutor(query);
            return dataPengajuanSempro;
        }

        public static DataTable show(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id_pengajuan_sempro = @id_pengajuan_sempro";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_pengajuan_sempro", NpgsqlDbType.Integer){Value = id},
            };
            DataTable dataPengajuanSempro = queryExecutor(query, parameters);
            return dataPengajuanSempro;
        }

        public static void store(M_PengajuanSempro pengajuanSemproBaru)
        {
            string query = $"INSERT INTO {table} (nama_mahasiswa, nim, prodi, total_sks, judul_proposal, tanggal_pengajuan, rumusan_masalah, draft_proposal, bukti_krs, bukti_dosen_pembimbing, topik, status, pembimbing1, pembimbing2) VALUES (@nama_mahasiswa, @nim, @prodi, @total_sks, @judul_proposal, @tanggal_pengajuan, @rumusan_masalah, @draft_proposal, @bukti_krs, @bukti_dosen_pembimbing, @topik, @status, @pembimbing1, @pembimbing2)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama_mahasiswa", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.nama_mahasiswa},
                new NpgsqlParameter("@nim", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.nim},
                new NpgsqlParameter("@prodi", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.prodi},
                new NpgsqlParameter("@total_sks", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.total_sks},
                new NpgsqlParameter("@judul_proposal", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.judul_proposal},
                new NpgsqlParameter("@tanggal_pengajuan", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.tanggal_pengajuan},
                new NpgsqlParameter("@rumusan_masalah", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.rumusan_masalah},
                new NpgsqlParameter("@draft_proposal", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.draft_proposal},
                new NpgsqlParameter("@bukti_krs", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.bukti_krs},
                new NpgsqlParameter("@bukti_dosen_pembimbing", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.bukti_dosen_pembimbing},
                new NpgsqlParameter("@topik", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.topik},
                new NpgsqlParameter("@status", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.status},
                new NpgsqlParameter("@pembimbing1", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.pembimbing1},
                new NpgsqlParameter("@pembimbing2", NpgsqlDbType.Varchar){Value = pengajuanSemproBaru.pembimbing2},
            };
            commandExecutor(query, parameters);
        }

        public static void destroy(int id)
        {
            string query = $"DELETE FROM {table} WHERE id_pengajuan_sempro = @id_pengajuan_sempro";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_pengajuan_sempro", NpgsqlDbType.Integer){Value = id},
            };
            commandExecutor(query, parameters);
        }

        public static void update(M_PengajuanSempro pengajuanSemproEdit)
        {
            string query = $"UPDATE {table} SET nama = @nama, nim = @nim, prodi = @prodi, total_sks = @total_sks, judul_proposal =@judul_proposal, tanggal_pengajuan = @tanggal_pengajuan, rumusan_masalah = @rumusan_masalah, draft_proposal = @draft_proposal, bukti_krs = @bukti_krs, bukti_dosen_pembimbing = @bukti_dosen_pembimbing, topik = @topik, status = @status, pembimbing1 = @pembimbing1, pembimbing2 = @pembimbing2 WHERE id_pengajuan_sempro = @id_pengajuan_sempro";
            NpgsqlParameter[] parameters =
            {
               new NpgsqlParameter("@nama", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.nama_mahasiswa},
                new NpgsqlParameter("@nim", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.nim},
                new NpgsqlParameter("@prodi", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.prodi},
                new NpgsqlParameter("@total_sks", NpgsqlDbType.Varchar){Value = pengajuanSemproEdit.total_sks},
                new NpgsqlParameter("@judul_proposal", NpgsqlDbType.Varchar){Value = pengajuanSemproEdit.judul_proposal},
                new NpgsqlParameter("@tanggal_pengajuan", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.tanggal_pengajuan},
                new NpgsqlParameter("@rumusan_masalah", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.rumusan_masalah},
                new NpgsqlParameter("@draft_proposal", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.draft_proposal},
                new NpgsqlParameter("@bukti_krs", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.bukti_krs},
                new NpgsqlParameter("@bukti_dosen_pembimbing", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.bukti_dosen_pembimbing},
                new NpgsqlParameter("@topik", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.topik},
                new NpgsqlParameter("@status", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.status},
                new NpgsqlParameter("@pembimbing1", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.pembimbing1},
                new NpgsqlParameter("@pembimbing2", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.pembimbing2},
                new NpgsqlParameter("@id_pengajuan_sempro", NpgsqlDbType.Integer){Value = pengajuanSemproEdit.pembimbing2},
            };
            commandExecutor(query, parameters);
        }

        public static void ubahPengajuan(int id_pengajuan_sempro, string nama, string nim, string judul, string rumusan_masalah, string topik, string tanggal_pengajuan, string pembimbing1, string pembimbing2, string prodi1, string draft_proposal, string bukti_krs, string bukti_dosen_pembimbing, string total_sks, string status)
        {
            string query = $"UPDATE {table} SET nama_mahasiswa = '{nama}', nim = '{nim}',judul_proposal = '{judul}',rumusan_masalah = '{rumusan_masalah}',topik = '{topik}',tanggal_pengajuan = '{tanggal_pengajuan}',pembimbing1 = '{pembimbing1}',pembimbing2 = '{pembimbing2}',prodi = '{prodi1}',draft_proposal = '{draft_proposal}',bukti_krs = '{bukti_krs}',bukti_dosen_pembimbing = '{bukti_dosen_pembimbing}',total_sks = '{total_sks}',status = '{status}' WHERE id_pengajuan_sempro = {id_pengajuan_sempro}";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_jadwal_sidang", NpgsqlDbType.Integer) { Value = id_pengajuan_sempro }
            };
            commandExecutor(query, parameters);

        }
        public static DataTable alldetail(string nama_dosen)
        {
            string query = $@"SELECT id_pengajuan_sempro, nama_mahasiswa,nim, prodi, judul_proposal, pembimbing1,pembimbing2 FROM {table} WHERE (pembimbing1 = '{nama_dosen}') OR (pembimbing2 = '{nama_dosen}')";
            DataTable dataPengajuanSempro = queryExecutor(query);
            return dataPengajuanSempro;

        }
    }
}