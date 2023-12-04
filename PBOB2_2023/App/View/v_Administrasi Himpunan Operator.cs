using PBOB2_2023.App.Context;
using PBOB2_2023.App.Model;
using System;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_AdministrasiHimpunanOperator : Form
    {
        int id;

        public v_AdministrasiHimpunanOperator()
        {
            InitializeComponent();
            dataGridView1.DataSource = HimpunanContext.all();

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = HimpunanContext.all();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void v_AdministrasiHimpunanOperator_buttonPengajuanSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_AdministrasiHimpunanOperator_buttonPengajuanSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();
        }

        private void v_AdministrasiHimpunanOperator_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_AdministrasiHimpunanOperator_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_AdministrasiHimpunanOperator_buttonDataDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_AdministrasiHimpunanOperator_buttonArsipJudul_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_AdministrasiHimpunanOperator_buttonAdministrasi_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var nama_himpunan = textboxMinat_v_operator.Text;
            var username = nama_himpunan;
            var sandi = username;

            M_Himpunan DataHimpunan = new M_Himpunan()
            {
                nama_himpunan = nama_himpunan,
            };

            M_UserLogin dataUser = new M_UserLogin()
            {
                username = username,
                sandi = sandi,
                peran = "Himpunan"
            };

            DialogResult message = MessageBox.Show("Apakah yakin ingin menambah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                HimpunanContext.store(DataHimpunan);
                UserLoginContext.store(dataUser);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = HimpunanContext.all();

            }
        }
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                textboxMinat_v_operator.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }

        private void button12_Click(object sender, EventArgs e)
        {
            HimpunanContext.destroy(id);
            DialogResult message = MessageBox.Show("Apakah yakin ingin menghapus data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
                MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = HimpunanContext.all();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            var nama_himpunan = textboxMinat_v_operator.Text;

            DialogResult message = MessageBox.Show("Apakah yakin merubah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                HimpunanContext.updateOperator(id, nama_himpunan);
                MessageBox.Show("Data berhasil diubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = HimpunanContext.all();
            }
        }
    }
}
