using Npgsql;
using NpgsqlTypes;
using PBOB2_2023.App.Core;
using PBOB2_2023.App.Model;
using System.Data;

namespace PBOB2_2023.App.Context
{
    internal class MahasiswaContext : DatabaseWrapper
    {
        private static string table = "mahasiswa";

        public static DataTable all()
        {
            string query = $"SELECT * FROM {table}";
            DataTable dataMahasiswa = queryExecutor(query);
            return dataMahasiswa;
        }

        public static DataTable show(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id_mahasiswa = @id_mahasiswa";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_mahasiswa", NpgsqlDbType.Integer){Value = id},
            };
            DataTable dataMahasiswa = queryExecutor(query, parameters);
            return dataMahasiswa;
        }

        public static void store(M_Mahasiswa mahasiswaBaru)
        {
            string query = $"INSERT INTO {table} (nama, nim, no_telpon, prodi) VALUES(@nama, @nim, @no_telpon, @prodi)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", NpgsqlDbType.Varchar){Value = mahasiswaBaru.nama},
                new NpgsqlParameter("@nim", NpgsqlDbType.Varchar){Value = mahasiswaBaru.nim},
                new NpgsqlParameter("@no_telpon", NpgsqlDbType.Varchar){Value = mahasiswaBaru.no_telpon},
                new NpgsqlParameter("@prodi", NpgsqlDbType.Varchar){Value = mahasiswaBaru.prodi},
            };
            commandExecutor(query, parameters);
        }

        public static void destroy(int id)
        {
            string query = $"DELETE FROM {table} WHERE id_mahasiswa = @id_mahasiswa";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_mahasiswa", NpgsqlDbType.Integer){Value = id},
            };
            commandExecutor(query, parameters);
        }

        public static void update(M_Mahasiswa mahasiswaEdit)
        {
            string query = $"UPDATE {table} SET nama = @nama, nim = @nim, prodi = @prodi WHERE id_mahasiswa = @id_mahasiswa";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", NpgsqlDbType.Varchar){Value = mahasiswaEdit.nama},
                new NpgsqlParameter("@nim", NpgsqlDbType.Varchar){Value = mahasiswaEdit.nim},
                new NpgsqlParameter("@no_telpon", NpgsqlDbType.Varchar){Value = mahasiswaEdit.no_telpon},
                new NpgsqlParameter("@prodi", NpgsqlDbType.Varchar){Value = mahasiswaEdit.prodi},
                new NpgsqlParameter("@id_mahasiswa", NpgsqlDbType.Integer){Value = mahasiswaEdit.id_mahasiswa},
            };
            commandExecutor(query, parameters);
        }
        public static void updateOperator(int id_mahasiswa, string nama, string nim, string no_telpon, string prodi)
        {
            string query = $"UPDATE {table} SET nama = '{nama}', nim = '{nim}', no_telpon = '{no_telpon}', prodi = '{prodi}' WHERE id_mahasiswa = '{id_mahasiswa}'";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_mahasiswa", NpgsqlDbType.Integer){Value = id_mahasiswa}
            };
            commandExecutor(query, parameters);
        }
    }
}
