using PBOB2_2023.App.Context;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Forms;
using PBOB2_2023.App.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBOB2_2023.View
{
    public partial class v_PengajuanSemproOperator : Form
    {
    private string dateFormat = "dd/MM/yyyy";
        int id_pengajuan_sempro;
        public v_PengajuanSemproOperator()
        {
            InitializeComponent();
            // Looping untuk get Real Data dari DataTable
            DataTable status = StatusContext.all();
            List<KeyValuePair<int, string>> validasi = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < status.Rows.Count; i++)
            {
                int idValidasi = Convert.ToInt32(status.Rows[i]["id_status"]);
                string jenisValidasi = status.Rows[i]["status"].ToString();

                validasi.Add(new KeyValuePair<int, string>(idValidasi, jenisValidasi));
            }
            comboBoxStatus_PengajuanSemproOperator.DataSource = validasi;
            comboBoxStatus_PengajuanSemproOperator.ValueMember = "Value";
            comboBoxStatus_PengajuanSemproOperator.DisplayMember = "Value";

            DataTable dataPembimbing1 = DosenContext.all();
            List<KeyValuePair<int, string>> pembimbing1 = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataPembimbing1.Rows.Count; i++)
            {
                int idPembimbing1 = Convert.ToInt32(dataPembimbing1.Rows[i]["id_dosen"]);
                string namaPembimbing1 = dataPembimbing1.Rows[i]["nama"].ToString();

                pembimbing1.Add(new KeyValuePair<int, string>(idPembimbing1, namaPembimbing1));
            }
            comboBoxPembimbing1_PengajuanSemproOperator.DataSource = pembimbing1;
            comboBoxPembimbing1_PengajuanSemproOperator.ValueMember = "Value";
            comboBoxPembimbing1_PengajuanSemproOperator.DisplayMember = "Value";

            DataTable dataPembimbing2 = DosenContext.all();
            List<KeyValuePair<int, string>> pembimbing2 = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataPembimbing2.Rows.Count; i++)
            {
                int idPembimbing2 = Convert.ToInt32(dataPembimbing2.Rows[i]["id_dosen"]);
                string namaPembimbing2 = dataPembimbing2.Rows[i]["nama"].ToString();

                pembimbing2.Add(new KeyValuePair<int, string>(idPembimbing2, namaPembimbing2));
            }
            comboBoxPembimbing2_PengajuanSemproOperator.DataSource = pembimbing2;
            comboBoxPembimbing2_PengajuanSemproOperator.ValueMember = "Value";
            comboBoxPembimbing2_PengajuanSemproOperator.DisplayMember = "Value";

            DataTable dataProdi = ProdiContext.all();
            List<KeyValuePair<int, string>> prodi1 = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataProdi.Rows.Count; i++)
            {
                int idProdi = Convert.ToInt32(dataProdi.Rows[i]["id_prodi"]);
                string namaProdi = dataProdi.Rows[i]["nama_prodi"].ToString();

                prodi1.Add(new KeyValuePair<int, string>(idProdi, namaProdi));
            }
            comboBoxProdi_PengajuanSemproOperator.DataSource = prodi1;
            comboBoxProdi_PengajuanSemproOperator.ValueMember = "Value";
            comboBoxProdi_PengajuanSemproOperator.DisplayMember = "Value";
        }

        private void v_PengajuanSemproOperator_buttonPengajuanSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_PengajuanSemproOperator_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_PengajuanSemproOperator_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_PengajuanSemproOperator_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_PengajuanSemproOperator_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_PengajuanSemproOperator_buttonAdministrasi_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_PengajuanSemproOperator_buttonValidasi_Click(object sender, System.EventArgs e)
        {
            var nama = textBoxNama_PengajuanSemproOperator.Text;
            var nim = textBoxNIM_PengajuanSemproOperator.Text;
            var judul = textBoxJudul_PengajuanSemproOperator.Text;
            var rumusan_masalah = textBoxRM_PengajuanSemproOperator.Text;
            var topik = textBoxTopik_PengajuanSemproOperator.Text;
            var tanggal_pengajuan = dateTimePicker1.Value.ToString(dateFormat);

            KeyValuePair<int, string> selectedPembimbing1 = (KeyValuePair<int, string>)comboBoxPembimbing1_PengajuanSemproOperator.SelectedItem;
            var pembimbing1 = selectedPembimbing1.Value;
            KeyValuePair<int, string> selectedPembimbing2 = (KeyValuePair<int, string>)comboBoxPembimbing2_PengajuanSemproOperator.SelectedItem;
            var pembimbing2 = selectedPembimbing2.Value;
            KeyValuePair<int, string> selectedProdi = (KeyValuePair<int, string>)comboBoxProdi_PengajuanSemproOperator.SelectedItem;
            var prodi1 = selectedProdi.Value;

            var draft_proposal = textBoxDraftPro_PengajuanSemproOperator.Text;
            var bukti_krs = textBoxKRS_PengajuanSemproOperator.Text;
            var bukti_dosen_pembimbing = textBoxBuktiSetuju_PengajuanSemproOperator.Text;
            var total_sks = textBoxTSKS_PengajuanSemproOperator.Text;

            KeyValuePair<int, string> selectedValidasi = (KeyValuePair<int, string>)comboBoxStatus_PengajuanSemproOperator.SelectedItem;
            var status = selectedValidasi.Value;

            DialogResult message = MessageBox.Show("Apakah yakin ingin memvalidasi?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PengajuanSemproContext.ubahPengajuan(id_pengajuan_sempro, nama, nim, judul, rumusan_masalah, topik, tanggal_pengajuan, pembimbing1, pembimbing2, prodi1, draft_proposal, bukti_krs, bukti_dosen_pembimbing, total_sks, status);
                MessageBox.Show("Berhasil Divalidasi", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void v_PengajuanSemproOperator_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PengajuanSemproContext.all();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_pengajuan_sempro = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBoxNama_PengajuanSemproOperator.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxNIM_PengajuanSemproOperator.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBoxProdi_PengajuanSemproOperator.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxTSKS_PengajuanSemproOperator.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxJudul_PengajuanSemproOperator.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            object valueTanggal = dataGridView1.Rows[e.RowIndex].Cells[6].Value;
            DateTime.TryParse(valueTanggal.ToString(), out DateTime result);
            dateTimePicker1.Value = result; 
            textBoxRM_PengajuanSemproOperator.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBoxDraftPro_PengajuanSemproOperator.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBoxKRS_PengajuanSemproOperator.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBoxBuktiSetuju_PengajuanSemproOperator.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBoxTopik_PengajuanSemproOperator.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            comboBoxStatus_PengajuanSemproOperator.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            comboBoxPembimbing1_PengajuanSemproOperator.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            comboBoxPembimbing2_PengajuanSemproOperator.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();

        }
    }
}
