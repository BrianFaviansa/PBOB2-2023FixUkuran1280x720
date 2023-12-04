using PBOB2_2023.App.Context;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_JadwalSidangKombi : Form
    {
        int id_jadwal_sidang;

        public v_JadwalSidangKombi()
        {
            InitializeComponent();
            dataGridView1.DataSource = PenjadwalanSidangSkripsiContext.all();
            DataTable dataPenguji1 = DosenContext.all();
            List<KeyValuePair<int, string>> Penguji1 = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataPenguji1.Rows.Count; i++)
            {
                int idPenguji1 = Convert.ToInt32(dataPenguji1.Rows[i]["id_dosen"]);
                string namaPenguji1 = dataPenguji1.Rows[i]["nama"].ToString();

                Penguji1.Add(new KeyValuePair<int, string>(idPenguji1, namaPenguji1));
            }
            comboBox1.DataSource = Penguji1;
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Value";


            DataTable dataPenguji2 = DosenContext.all();
            List<KeyValuePair<int, string>> Penguji2 = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataPenguji2.Rows.Count; i++)
            {
                int idPenguji2 = Convert.ToInt32(dataPenguji2.Rows[i]["id_dosen"]);
                string namaPenguji2 = dataPenguji2.Rows[i]["nama"].ToString();

                Penguji2.Add(new KeyValuePair<int, string>(idPenguji2, namaPenguji2));
            }
            comboBox2.DataSource = Penguji2;
            comboBox2.ValueMember = "Value";
            comboBox2.DisplayMember = "Value";

        }

        private void v_JadwalSidangKombi_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproKombi().Show();

        }

        private void v_JadwalSidangKombi_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenKombi().Show();
        }

        private void v_JadwalSidangKombi_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulKombi().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_JadwalSidangKombi_Load(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = PenjadwalanSidangSkripsiContext.all();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            KeyValuePair<int, string> selectedPenguji1 = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            var Penguji1 = selectedPenguji1.Value;
            KeyValuePair<int, string> selectedPenguji2 = (KeyValuePair<int, string>)comboBox2.SelectedItem;
            var Penguji2 = selectedPenguji2.Value;


            DialogResult message = MessageBox.Show("Apakah yakin menambah penguji?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PenjadwalanSidangSkripsiContext.updateKombi(id_jadwal_sidang, Penguji1, Penguji2);
                MessageBox.Show("Penguji berhasil ditambah", "Sukses", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                dataGridView1.DataSource = PenjadwalanSidangSkripsiContext.all();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            KeyValuePair<int, string> selectedPenguji1 = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            var Penguji1 = selectedPenguji1.Value;
            KeyValuePair<int, string> selectedPenguji2 = (KeyValuePair<int, string>)comboBox2.SelectedItem;
            var Penguji2 = selectedPenguji2.Value;


            DialogResult message = MessageBox.Show("Apakah yakin mengubah penguji?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PenjadwalanSidangSkripsiContext.updateKombi(id_jadwal_sidang, Penguji1, Penguji2);
                MessageBox.Show("Penguji berhasil dirubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = PenjadwalanSidangSkripsiContext.all();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_jadwal_sidang = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();

        }
    }
}
