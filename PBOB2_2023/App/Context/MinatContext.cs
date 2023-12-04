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
using System.Windows.Forms;

namespace PBOB2_2023.App.Context
{
    internal class MinatContext : DatabaseWrapper
    {
        private static string table = "minat";

        public static DataTable all()
        {
            string query = $"SELECT * FROM {table}";
            DataTable dataMinat = queryExecutor(query);
            return dataMinat;
        }

        public static DataTable show(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id_minat = @id_minat";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_minat", NpgsqlTypes.NpgsqlDbType.Integer){Value = id},
            };
            DataTable dataMinat = queryExecutor(query, parameters);
            return dataMinat;
        }

        public static void store(M_Minat minatBaru)
        {
            string query = $"INSERT INTO {table} (minat, detail_minat) VALUES (@minat, @detail_minat)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@minat", NpgsqlDbType.Varchar){Value = minatBaru.minat},
                new NpgsqlParameter("@detail_minat", NpgsqlDbType.Varchar){Value = minatBaru.minat},
            };
            commandExecutor(query, parameters);
        }

        public static void update(M_Minat minatEdit)
        {
            string query = $"UPDATE {table} SET minat = @minat WHERE id_minat = @id_minat";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama_minat", NpgsqlDbType.Varchar){Value = minatEdit.minat},
                new NpgsqlParameter("@id_minat", NpgsqlDbType.Integer){Value = minatEdit.id_minat}
            };
            commandExecutor(query, parameters);
        }

        public static void destroy(int id)
        {
            string query = $"DELETE FROM {table} WHERE id_minat = @id_minat";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_minat", NpgsqlDbType.Integer){Value = id},
            };
            commandExecutor(query, parameters);
        }

        public static void updateOperator(int id_minat, string minat, string detail_minat)
        {
            string query = $"UPDATE {table} SET minat = '{minat}', detail_minat = '{detail_minat}' WHERE id_minat = '{id_minat}'";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_minat", NpgsqlDbType.Integer){Value = id_minat}
            };
            commandExecutor(query, parameters);

        }
        public static DataTable alldistinctminat()
        {
            string query = $"SELECT DISTINCT minat FROM {table}";
            DataTable dataMinat = queryExecutor(query);
            return dataMinat;
        }
        public static DataTable alldistinctdetailminat(string minatselected)
        {
            string query = $"SELECT DISTINCT detail_minat FROM {table} WHERE minat = '{minatselected}'";
            //MessageBox.Show(query);
            DataTable dataMinat = queryExecutor(query);
            return dataMinat;
        }
    }
}
