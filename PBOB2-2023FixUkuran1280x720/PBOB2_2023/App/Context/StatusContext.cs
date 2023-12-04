using PBOB2_2023.App.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOB2_2023.App.Context
{
    internal class StatusContext : DatabaseWrapper
    {
        private static string table = "status";

        public static DataTable all()
        {
            string query = $"SELECT * FROM {table}";
            DataTable dataProdi = queryExecutor(query);
            return dataProdi;
        }
    }
}
