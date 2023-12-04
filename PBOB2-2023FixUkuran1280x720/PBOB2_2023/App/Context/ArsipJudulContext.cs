using PBOB2_2023.App.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBOB2_2023.App.Context
{
    internal class ArsipJudulContext : DatabaseWrapper
    {
        private static string table = "penjadwalan_sidang_skripsi";

        public static DataTable all(string status)
        {
            string query = $"SELECT nama_mahasiswa, nim, prodi, judul, pembimbing1, pembimbing2, penguji1, penguji2 from {table} WHERE status = '{status}'";
            DataTable dataDosen = queryExecutor(query);
            return dataDosen;
        }

        public static DataTable cari(string cari)
        {
            string query = $"SELECT nama_mahasiswa, nim, prodi, judul, pembimbing1, pembimbing2, penguji1, penguji2 from {table} WHERE nama_mahasiswa = '{cari}'";
            DataTable dataDosen = queryExecutor(query);
            return dataDosen;
        }
    }
}
