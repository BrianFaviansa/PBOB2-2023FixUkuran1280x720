using Npgsql;
using NpgsqlTypes;
using PBOB2_2023.App.Core;
using PBOB2_2023.App.Model;
using System.Data;

namespace PBOB2_2023.App.Context
{
    internal class ProdiContext : DatabaseWrapper
    {
        private static string table = "prodi";

        public static DataTable all()
        {
            string query = $"SELECT * FROM {table}";
            DataTable dataProdi = queryExecutor(query);
            return dataProdi;
        }

        public static DataTable show(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id_prodi = @id_prodi";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_prodi", NpgsqlTypes.NpgsqlDbType.Integer){Value = id},
            };
            DataTable dataProdi = queryExecutor(query, parameters);
            return dataProdi;
        }

        public static void store(M_Prodi prodiBaru)
        {
            string query = $"INSERT INTO {table} (nama_prodi) VALUES (@nama_prodi)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama_prodi", NpgsqlDbType.Varchar){Value = prodiBaru.nama_prodi},
            };
            commandExecutor(query, parameters);
        }

        public static void update(M_Prodi prodiEdit)
        {
            string query = $"UPDATE {table} SET nama_prodi = @nama_prodi WHERE id_prodi = @id_prodi";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama_prodi", NpgsqlDbType.Varchar){Value = prodiEdit.nama_prodi},
                new NpgsqlParameter("@id_prodi", NpgsqlDbType.Integer){Value = prodiEdit.id_prodi}
            };
            commandExecutor(query, parameters);
        }

        public static void destroy(int id)
        {
            string query = $"DELETE FROM {table} WHERE id_prodi = @id_prodi";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_prodi", NpgsqlDbType.Integer){Value = id},
            };
            commandExecutor(query, parameters);
        }

        public static void updateOperator(int id_prodi, string nama_prodi)
        {
            string query = $"UPDATE {table} SET nama_prodi = '{nama_prodi}' WHERE id_prodi = '{id_prodi}'";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_prodi", NpgsqlDbType.Integer){Value = id_prodi}
            };
            commandExecutor(query, parameters);
        }
    }
}

