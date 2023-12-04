using PBOB2_2023.App.Context;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_JadwalSemproDosen : Form
    {
        int id;
        public v_JadwalSemproDosen()
        {
            InitializeComponent();
            DataTable status = StatusContext.all();
            List<KeyValuePair<int, string>> validasi = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < status.Rows.Count; i++)
            {
                int idValidasi = Convert.ToInt32(status.Rows[i]["id_status"]);
                string validasistatus = status.Rows[i]["status"].ToString();

                validasi.Add(new KeyValuePair<int, string>(idValidasi, validasistatus));
            }
            comboBox1.DataSource = validasi;
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Value";

        }

        private void v_JadwalSemproDosen_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangDosen().Show();
        }

        private void v_JadwalSemproDosen_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenDosen().Show();
        }

        private void v_JadwalSemproDosen_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulDosen().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_JadwalSemproDosen_Load(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = PenjadwalanSemproContext.all();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            KeyValuePair<int, string> selectedstatus = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            var status = selectedstatus.Value;


            DialogResult message = MessageBox.Show("Apakah yakin merubah status?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PenjadwalanSemproContext.ubahStatus(id, status);
                MessageBox.Show("Status berhasil dirubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = PenjadwalanSemproContext.all();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
        }
    }
}
