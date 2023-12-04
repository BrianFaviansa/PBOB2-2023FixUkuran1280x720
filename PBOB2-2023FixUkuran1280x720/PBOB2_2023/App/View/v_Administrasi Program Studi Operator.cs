using PBOB2_2023.App.Context;
using PBOB2_2023.App.Model;
using System;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_AdministrasirogramStudiOperator : Form
    {
        int id;
        public v_AdministrasirogramStudiOperator()
        {
            InitializeComponent();
            dataGridView1.DataSource = ProdiContext.all();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ProdiContext.all();
        }

        private void v_AdministrasirogramStudiOperator_buttonPengajuanSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_AdministrasirogramStudiOperator_buttonPengajuanSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_AdministrasirogramStudiOperator_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();
        }

        private void v_AdministrasirogramStudiOperator_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_AdministrasirogramStudiOperator_buttonDataDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_AdministrasirogramStudiOperator_buttonArsipJudul_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_AdministrasirogramStudiOperator_buttonAdministrasi_Click(object sender, EventArgs e)
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
            var program_studi = textboxMinat_v_operator.Text;

            M_Prodi nama_prodi = new M_Prodi()
            {
                nama_prodi = program_studi,

            };
            DialogResult message = MessageBox.Show("Apakah yakin ingin menambah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                ProdiContext.store(nama_prodi);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = ProdiContext.all();

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ProdiContext.destroy(id);
            DialogResult message = MessageBox.Show("Apakah yakin ingin menghapus data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
                MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = ProdiContext.all();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textboxMinat_v_operator.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var nama_prodi = textboxMinat_v_operator.Text;

            DialogResult message = MessageBox.Show("Apakah yakin merubah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                ProdiContext.updateOperator(id, nama_prodi);
                MessageBox.Show("Status berhasil dirubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = ProdiContext.all();

            }
        }
    }
}
