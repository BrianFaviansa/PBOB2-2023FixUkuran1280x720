using PBOB2_2023.App.Context;
using PBOB2_2023.App.Model;
using PBOB2_2023.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBOB2_2023.App.View
{
    public partial class v_User_Login_Operator : Form
    {
        int id;
        public v_User_Login_Operator()
        {
            InitializeComponent();
            dataGridView1.DataSource = UserLoginContext.all();

            DataTable dataUserLogin = UserLoginContext.all();
            List<KeyValuePair<int, string>> peran = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataUserLogin.Rows.Count; i++)
            {
                int idPeran = Convert.ToInt32(dataUserLogin.Rows[i]["id_user_login"]);
                string namaPeran = dataUserLogin.Rows[i]["peran"].ToString();

                peran.Add(new KeyValuePair<int, string>(idPeran, namaPeran));
            }
            comboBox1.DataSource = peran;
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Value";

        }



        private void v_User_Login_Operator_buttonPengajuanSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
;           new v_PengajuanSidangOperator().Show();
        }

        private void v_User_Login_Operator_buttonPengajuanSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();
        }

        private void v_User_Login_Operator_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_User_Login_Operator_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_User_Login_Operator_buttonDataDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_User_Login_Operator_buttonArsipJudul_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_User_Login_Operator_buttonAdministrasi_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var sandi = textBox2.Text;
            KeyValuePair<int, string> selectedPeran = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            var peran = selectedPeran.Value;

            M_UserLogin userLoginBaru = new M_UserLogin
            {
                username = username,
                sandi = sandi,
                peran = peran
            };
            DialogResult message = MessageBox.Show("Apakah yakin ingin menyimpan?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                UserLoginContext.store(userLoginBaru);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            }
        }

            private void button2_Click(object sender, EventArgs e)
            {
                var username = textBox1.Text;
                var sandi = textBox2.Text;
                KeyValuePair<int, string> selectedPeran = (KeyValuePair<int, string>)comboBox1.SelectedItem;
                var peran = selectedPeran.Value;

                M_UserLogin userLoginBaru = new M_UserLogin
                {
                    username = username,
                    sandi = sandi,
                    peran = peran,
                };

                DialogResult message = MessageBox.Show("Apakah yakin merubah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    UserLoginContext.updateOperator(id, username, sandi, peran);
                    MessageBox.Show("Data berhasil dirubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = UserLoginContext.all();
                }
            }

            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserLoginContext.destroy(id);
            DialogResult message = MessageBox.Show("Apakah yakin ingin menghapus data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
                MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = UserLoginContext.all();

        }

        private void v_User_Login_Operator_buttonAdministrasi_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }
    } 

}
