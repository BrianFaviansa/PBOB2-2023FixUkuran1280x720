using PBOB2_2023.App.Context;
using PBOB2_2023.App.Model;
using PBOB2_2023.View;
using System;
using System.Windows.Forms;

namespace PBOB2_2023
{
    public partial class v_AdministrasiDosenMinatOperator : Form
    {
        int id;
        public v_AdministrasiDosenMinatOperator()
        {
            InitializeComponent();
            dataGridView1.DataSource = MinatContext.all();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DosenMinatContext.all();
        }

        private void v_AdministrasiDosenMinatOperator_buttonPengajuanSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_AdministrasiDosenMinatOperator_buttonPengajuanSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();
        }

        private void v_AdministrasiDosenMinatOperator_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_AdministrasiDosenMinatOperator_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_AdministrasiDosenMinatOperator_buttonDataDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_AdministrasiDosenMinatOperator_buttonArsipJudul_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_AdministrasiDosenMinatOperator_buttonAdministrasi_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MinatContext.destroy(id);
            DialogResult message = MessageBox.Show("Apakah yakin ingin menghapus data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
                MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = MinatContext.all();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var minat = textboxMinat_v_operator.Text;
            var detailminat = textboxDetailMinat_v_operator.Text;

            M_Minat dataminat = new M_Minat()
            {
                minat = minat,
                detail_minat = detailminat,
            };
            DialogResult message = MessageBox.Show("Apakah yakin ingin menambah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                MinatContext.store(dataminat);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = MinatContext.all();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textboxMinat_v_operator.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textboxDetailMinat_v_operator.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            var minat = textboxMinat_v_operator.Text;
            var detailminat = textboxDetailMinat_v_operator.Text;

            DialogResult message = MessageBox.Show("Apakah yakin merubah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                MinatContext.updateOperator(id, minat, detailminat);
                MessageBox.Show("Data berhasil dirubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = MinatContext.all();


            }
        }
    }
}
