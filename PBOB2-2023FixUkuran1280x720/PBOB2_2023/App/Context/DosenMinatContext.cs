using Npgsql;
using NpgsqlTypes;
using PBOB2_2023.App.Core;
using PBOB2_2023.App.Model;
using System.Data;

namespace PBOB2_2023.App.Context
{
    internal class DosenMinatContext : DatabaseWrapper
    {
        private static string table = "dosen_minat";

        public static DataTable all()
        {
            string query = $"SELECT * FROM {table} ORDER BY id_dosen_minat";
            DataTable dataDosenMinat = queryExecutor(query);
            return dataDosenMinat;

        }

        public static DataTable show(int id_dosen_minat)
        {
            string query = $"SELECT * FROM {table} WHERE id_dosen_minat = @id_dosen_minat";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id", NpgsqlDbType.Integer){Value = id_dosen_minat},
            };
            DataTable dataDosenMinat = queryExecutor(query, parameters);
            return dataDosenMinat;
        }

        public static void store(M_DosenMinat DosenMinatBaru)
        {
            string query = $"INSERT INTO {table}(nama, minat, detail_minat) VALUES(@nama, @minat, @detail_minat)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", NpgsqlDbType.Varchar){Value = DosenMinatBaru.nama},
                new NpgsqlParameter("@minat", NpgsqlDbType.Varchar){Value = DosenMinatBaru.minat},
                new NpgsqlParameter("@detail_minat", NpgsqlDbType.Varchar){Value = DosenMinatBaru.detail_minat},
            };
            commandExecutor(query, parameters);
        }

        public static void destroy(int id_dosen_minat)
        {
            string query = $"DELETE FROM {table} WHERE id_dosen_minat = @id_dosen_minat";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_dosen_minat", NpgsqlDbType.Integer){Value = id_dosen_minat},
            };
            commandExecutor(query, parameters);

        }

        public static void update(int id, M_DosenMinat DosenMinatEdit)
        {
            string query = $"UPDATE {table} SET nama = @nama, minat = @minat, detail_minat = @detailminat WHERE id_dosen_minat = '{id}'";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", NpgsqlDbType.Varchar){Value = DosenMinatEdit.nama},
                new NpgsqlParameter("@minat", NpgsqlDbType.Varchar){Value = DosenMinatEdit.minat},
                new NpgsqlParameter("@detailminat", NpgsqlDbType.Varchar){Value = DosenMinatEdit.detail_minat}
            };
            commandExecutor(query, parameters);
        }
        public static DataTable alldistinctnama()
        {
            string query = $"SELECT DISTINCT nama FROM {table}";
            DataTable dataDosenMinat = queryExecutor(query);
            return dataDosenMinat;
        }


    }
}
