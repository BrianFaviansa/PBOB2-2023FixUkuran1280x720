using Npgsql;
using NpgsqlTypes;
using PBOB2_2023.App.Core;
using PBOB2_2023.App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOB2_2023.App.Context
{
    internal class HimpunanContext : DatabaseWrapper
    {
        private static string table = "himpunan";

        public static DataTable all()
        {
            string query = $"SELECT * FROM {table}";
            DataTable dataProdi = queryExecutor(query);
            return dataProdi;
        }

        public static DataTable show(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id_himpunan = @id_himpunan";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_himpunan", NpgsqlDbType.Integer){Value = id},
            };
            DataTable dataProdi = queryExecutor(query, parameters);
            return dataProdi;
        }

        public static void store(M_Himpunan himpunanBaru)
        {
            string query = $"INSERT INTO {table} (nama_himpunan) VALUES (@nama_himpunan)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama_himpunan", NpgsqlDbType.Varchar){Value = himpunanBaru.nama_himpunan},
            };
            commandExecutor(query, parameters);
        }

        public static void update(M_Himpunan himpunanEdit)
        {
            string query = $"UPDATE {table} SET nama_himpunan = @nama_himpunan WHERE id_himpunan = @id_himpunan";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama_himpunan", NpgsqlDbType.Integer){Value = himpunanEdit.id_himpunan},
                new NpgsqlParameter("@id_himpunan", NpgsqlDbType.Varchar){Value = himpunanEdit.nama_himpunan},
            };
            commandExecutor(query, parameters);
        }

        public static void destroy(int id)
        {
            string query = $"DELETE FROM {table} WHERE id_himpunan = @id_himpunan";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_himpunan", NpgsqlDbType.Integer){Value = id},
            };
            commandExecutor(query, parameters);
        }
        public static void updateOperator(int id_himpunan, string nama_himpunan)
        {
            string query = $"UPDATE {table} SET nama_himpunan = '{nama_himpunan}' WHERE id_himpunan = '{id_himpunan}'";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_himpunan", NpgsqlDbType.Integer){Value = id_himpunan}
            };
            commandExecutor(query, parameters);
        }
    }
}
