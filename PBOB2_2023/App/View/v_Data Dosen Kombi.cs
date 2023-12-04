using PBOB2_2023.App.Context;
using PBOB2_2023.App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_DataDosenKombi : Form
    {
        
        int id_data_dosen_kombi;
        public string dataselected { get; private set; }
        public v_DataDosenKombi()
        {
            InitializeComponent();
            dataGridView1.DataSource = DosenMinatContext.all();

            DataTable datanama = DosenMinatContext.alldistinctnama();
            List<string> nama = new List<string>();

            for (int i = 0; i < datanama.Rows.Count; i++)
            {
                string nama_dosen = datanama.Rows[i]["nama"].ToString();
                nama.Add(nama_dosen);
            }

            comboBox1.DataSource = nama;

            DataTable dataminat = MinatContext.alldistinctminat();
            List<string> minat = new List<string>();

            for (int i = 0; i < dataminat.Rows.Count; i++)
            {
                string minat_dosen = dataminat.Rows[i]["minat"].ToString();
                minat.Add(minat_dosen);
            }

            comboBox2.DataSource = minat;

            dataselected = comboBox2.SelectedItem.ToString();

            DataTable datadetailminat = MinatContext.alldistinctdetailminat(dataselected);
            List<string> detail_minat = new List<string>();

            for (int i = 0; i < datadetailminat.Rows.Count; i++)
            {
                string detail_minat_dosen = datadetailminat.Rows[i]["detail_minat"].ToString();
                detail_minat.Add(detail_minat_dosen);
            }
            comboBox3.DataSource = detail_minat;
        }
        private void v_DataDosenKombi_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproKombi().Show();
        }

        private void v_DataDosenKombi_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangKombi().Show();
        }

        private void v_DataDosenKombi_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulKombi().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_DataDosenKombi_Load(object sender, System.EventArgs e)
        {

        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_data_dosen_kombi = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        private void button12_Click(object sender, System.EventArgs e)
        {
            string nama_dosen = comboBox1.SelectedItem.ToString();
            string minat = comboBox2.SelectedItem.ToString();
            string detailminat = comboBox3.SelectedItem.ToString();

            M_DosenMinat DosenMinatBaru = new M_DosenMinat()
            {
                nama = nama_dosen,
                minat = minat,
                detail_minat = detailminat,
            };
            DialogResult message = MessageBox.Show("Apakah yakin menambah detail minat?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                DosenMinatContext.store(DosenMinatBaru);
                MessageBox.Show("Penguji berhasil dirubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Question);
                dataGridView1.DataSource = DosenMinatContext.all();

            }
        }

        private void button10_Click(object sender, System.EventArgs e)
        {
            string nama_dosen = comboBox1.SelectedItem.ToString();
            string minat = comboBox2.SelectedItem.ToString();
            string detailminat = comboBox3.SelectedItem.ToString();

            M_DosenMinat DosenMinatEdit = new M_DosenMinat()
            {
                nama = nama_dosen,
                minat = minat,
                detail_minat = detailminat,
            };
            DialogResult message = MessageBox.Show("Apakah yakin merubah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                DosenMinatContext.update(id_data_dosen_kombi, DosenMinatEdit);
                MessageBox.Show("Penguji berhasil dirubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Question);
                dataGridView1.DataSource = DosenMinatContext.all();

            }
        }

        private void button11_Click(object sender, System.EventArgs e)
        {
            DosenMinatContext.destroy(id_data_dosen_kombi);
            DialogResult message = MessageBox.Show("Apakah yakin ingin menghapus data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
                MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Question);
            dataGridView1.DataSource = DosenMinatContext.all();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            string nama_dosen = comboBox1.SelectedItem.ToString();
            new v_DataDosenKombiBimbingan(nama_dosen).Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string nama_minat = comboBox2.SelectedItem.ToString();

            DataTable datadetailminat = MinatContext.alldistinctdetailminat(nama_minat);
            List<string> detail_minat = new List<string>();

            for (int i = 0; i < datadetailminat.Rows.Count; i++)
            {
                string detail_minat_dosen = datadetailminat.Rows[i]["detail_minat"].ToString();
                detail_minat.Add(detail_minat_dosen);
            }

            comboBox3.DataSource = detail_minat;
        }
    }
}
