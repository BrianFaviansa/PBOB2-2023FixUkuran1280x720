using PBOB2_2023.App.Context;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Forms;
using PBOB2_2023.App.Model;

namespace PBOB2_2023.View
{
    public partial class v_AdministrasiMahasiswaOperator : Form
    {
        int id;
        public v_AdministrasiMahasiswaOperator()
        {
            InitializeComponent();
            dataGridView1.DataSource = MahasiswaContext.all();
            DataTable datanama_prodi = ProdiContext.all();
            List<KeyValuePair<int, string>> prodi = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < datanama_prodi.Rows.Count; i++)
            {
                int idnama_prodi = Convert.ToInt32(datanama_prodi.Rows[i]["id_prodi"]);
                string nama_prodi = datanama_prodi.Rows[i]["nama_prodi"].ToString();

                prodi.Add(new KeyValuePair<int, string>(idnama_prodi, nama_prodi));
            }
            comboBox1.DataSource = prodi;
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Value";
        }

        private void v_AdministrasiMahasiswaOperator_buttonPengajuanSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_AdministrasiMahasiswaOperator_buttonPengajuanSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();
        }

        private void v_AdministrasiMahasiswaOperator_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_AdministrasiMahasiswaOperator_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_AdministrasiMahasiswaOperator_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_AdministrasiMahasiswaOperator_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_AdministrasiMahasiswaOperator_buttonAdministrasi_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_AdministrasiMahasiswaOperator_Load(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = MahasiswaContext.all();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var nama = textBox2.Text;
            var nim = textBox3.Text;
            var no_telpon = textBox4.Text;
            KeyValuePair<int, string> selectednama_prodi = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            var prodi = selectednama_prodi.Value;
            var username = nim;
            var sandi = nim.Substring(8, 4);


            M_Mahasiswa datamahasiswa = new M_Mahasiswa()
            {
                nama = nama,
                nim = nim,
                no_telpon = no_telpon,
                prodi = prodi

            };

            M_UserLogin datauser = new M_UserLogin()
            {
                username = username,
                sandi = sandi,
                peran = "Mahasiswa"
            };

            DialogResult message = MessageBox.Show("Apakah yakin ingin menambah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                MahasiswaContext.store(datamahasiswa);
                UserLoginContext.store(datauser);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = MahasiswaContext.all();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MahasiswaContext.destroy(id);
            DialogResult message = MessageBox.Show("Apakah yakin ingin menghapus data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
                MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = MahasiswaContext.all();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            var nama = textBox2.Text;
            var nim = textBox3.Text;
            var no_telpon = textBox4.Text;
            KeyValuePair<int, string> selectednama_prodi = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            var prodi = selectednama_prodi.Value;

            DialogResult message = MessageBox.Show("Apakah yakin merubah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                MahasiswaContext.updateOperator(id, nama, nim, no_telpon, prodi);
                MessageBox.Show("Data berhasil dirubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = MahasiswaContext.all();

            }
        }
    }
}
