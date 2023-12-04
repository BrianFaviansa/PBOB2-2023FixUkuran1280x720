using Npgsql;
using PBOB2_2023.View;
using System;
using System.Data;
using System.Windows.Forms;

namespace PBOB2_2023.App.Core
{
    internal class CekLogin
    {
        public static bool Login(string username, string sandi)
        {
            try
            {
                // Menggunakan parameterized query untuk mencegah SQL Injection
                string query = "SELECT peran FROM user_login WHERE username = @username AND sandi = @sandi";

                // Menyiapkan parameter
                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                new NpgsqlParameter("@username", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = username },
                new NpgsqlParameter("@sandi", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = sandi },
                };


                // Menjalankan query menggunakan DatabaseWrapper
                DataTable result = DatabaseWrapper.queryExecutor(query, parameters);

                // Memeriksa hasil login
                if (result.Rows.Count > 0)
                {
                    // Login berhasil, Anda dapat memeriksa role dari hasil query
                    string peran = (result.Rows[0]["peran"]).ToString();

                    // Menggunakan nilai roleId untuk menentukan peran pengguna
                    switch (peran)
                    {
                        case "Operator":
                            MessageBox.Show("Login Berhasil!", "Operator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new v_JadwalSemproOperator().Show();
                            break;
                        case "Kombi":
                            MessageBox.Show("Login Berhasil!", "Kombi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new v_JadwalSemproKombi().Show();
                            break;
                        case "Mahasiswa":
                            MessageBox.Show("Login Berhasil!", "Mahasiswa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new v_JadwalSemproMahasiswa().Show();
                            break;
                        case "Hima":
                            MessageBox.Show("Login Berhasil!", "Hima", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new v_JadwalSidangHimpunan().Show();
                            break;
                        case "Dosen":
                            MessageBox.Show("Login Berhasil!", "Dosen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new v_JadwalSemproDosen().Show();
                            break;
                        default:
                            Console.WriteLine("Login berhasil! Peran pengguna tidak dikenali");
                            break;
                    }

                    return true;
                }
                else
                {
                    Console.WriteLine("Login gagal! Username atau password salah.");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Terjadi kesalahan: {e.Message}");
                return false;
            }
        }
    }
}
