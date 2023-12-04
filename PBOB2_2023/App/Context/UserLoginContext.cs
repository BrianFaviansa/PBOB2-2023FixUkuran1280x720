using Npgsql;
using NpgsqlTypes;
using PBOB2_2023.App.Core;
using PBOB2_2023.App.Model;
using System.Data;

namespace PBOB2_2023.App.Context
{
    internal class UserLoginContext : DatabaseWrapper
    {
        private static string table = "user_login";

        public static DataTable all()
        {
            string query = $"SELECT * FROM {table}";
            DataTable dataUserLogin = queryExecutor(query);
            return dataUserLogin;
        }

        public static DataTable show(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id_user_login = @id_user_login";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_user_login", NpgsqlDbType.Integer){Value = id},
            };
            DataTable dataUserLogin = queryExecutor(query, parameters);
            return dataUserLogin;
        }

        public static void store(M_UserLogin userLoginBaru)
        {
            string query = $"INSERT INTO {table} (username, sandi, peran) VALUES(@username, @sandi, @peran)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@username", NpgsqlDbType.Varchar){Value = userLoginBaru.username},
                new NpgsqlParameter("@sandi", NpgsqlDbType.Varchar){Value = userLoginBaru.sandi},
                new NpgsqlParameter("@peran", NpgsqlDbType.Integer){Value = userLoginBaru.peran},
            };
            commandExecutor(query, parameters);
        }

        public static void destroy(int id)
        {
            string query = $"DELETE FROM {table} WHERE id_user_login = @id_user_login";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_user_login", NpgsqlDbType.Integer){Value = id},
            };
            commandExecutor(query, parameters);
        }

        public static void update(M_UserLogin userLoginEdit)
        {
            string query = $"UPDATE {table} SET username = @username, sandi = @sandi, id_peran = @id_peran";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@username", NpgsqlDbType.Varchar){Value = userLoginEdit.username},
                new NpgsqlParameter("@sandi", NpgsqlDbType.Varchar){Value = userLoginEdit.sandi},
                new NpgsqlParameter("@peran", NpgsqlDbType.Integer){Value = userLoginEdit.peran},
                new NpgsqlParameter("@id_user_login", NpgsqlDbType.Integer){Value = userLoginEdit.id_user_login},
            };
            commandExecutor(query, parameters);
        }

        public static void updateOperator(int id_user_login, string username, string sandi, string peran)
        {
            string query = $"UPDATE {table} SET username = '{username}', sandi = '{sandi}', peran = '{peran}' WHERE id_user_login = '{id_user_login}'";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_user_login", NpgsqlDbType.Integer){Value = id_user_login}
            };
            commandExecutor(query, parameters);
        }

        public static DataTable AmbilPeran()
        {
            string query = $"SELECT peran FROM {table}";
            DataTable dataUserLogin = queryExecutor(query);
            return dataUserLogin;
        }

    }
}
