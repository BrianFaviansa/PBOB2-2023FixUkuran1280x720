using Npgsql;
using NpgsqlTypes;
using PBOB2_2023.App.Core;
using PBOB2_2023.App.Model;
using System.Data;

namespace PBOB2_2023.App.Context
{
    internal class DosenContext : DatabaseWrapper
    {
        private static string table = "dosen";
        public static DataTable all()
        {
            string query = $"SELECT * from {table}";
            DataTable dataDosen = queryExecutor(query);
            return dataDosen;
        }

        public static DataTable show(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id_dosen = @id_dosen";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_dosen", NpgsqlDbType.Integer){Value = id},
            };
            DataTable dataDosen = queryExecutor(query, parameters);
            return dataDosen;
        }

        public static void store(M_Dosen dosenBaru)
        {
            string query = $"INSERT INTO {table} (nama, no_telepon) VALUES(@nama, @no_telepon)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", NpgsqlDbType.Varchar){Value = dosenBaru.nama},
                new NpgsqlParameter("@no_telepon", NpgsqlDbType.Varchar){Value = dosenBaru.no_telepon},
            };
            commandExecutor(query, parameters);
        }

        public static void destroy(int id)
        {
            string query = $"DELETE FROM {table} WHERE id_dosen = @id_dosen";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_dosen", NpgsqlDbType.Integer){Value = id},
            };
            commandExecutor(query, parameters);
        }

        public static void update(M_Dosen dosenEdit)
        {
            string query = $"UPDATE {table} SET nama = @nama, no_telepon = @no_telepon, id_dosen = @id_dosen";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", NpgsqlDbType.Varchar){Value = dosenEdit.nama},
                new NpgsqlParameter("@no_telepon", NpgsqlDbType.Varchar){Value = dosenEdit.no_telepon},
                new NpgsqlParameter("@id_dosen", NpgsqlDbType.Integer){Value = dosenEdit.id_dosen},
            };
            commandExecutor(query, parameters);
        }

        public static void updateOperator(int id_dosen, string nama, string no_telepon)
        {
            string query = $"UPDATE {table} SET nama = '{nama}', no_telepon = '{no_telepon}' WHERE id_dosen = '{id_dosen}'";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_dosen", NpgsqlDbType.Integer){Value = id_dosen}
            };
            commandExecutor(query, parameters);
        }
    }
}
