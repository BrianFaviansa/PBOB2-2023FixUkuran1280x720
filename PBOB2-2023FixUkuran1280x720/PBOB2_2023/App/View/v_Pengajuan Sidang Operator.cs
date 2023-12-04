using PBOB2_2023.App.Context;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_PengajuanSidangOperator : Form
    {
        int id_pengajuan_sidang;
        public v_PengajuanSidangOperator()
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
            comboBox3.DataSource = validasi;
            comboBox3.ValueMember = "Value";
            comboBox3.DisplayMember = "Value";

            DataTable dataPembimbing1 = DosenContext.all();
            List<KeyValuePair<int, string>> pembimbing1 = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataPembimbing1.Rows.Count; i++)
            {
                int idPembimbing1 = Convert.ToInt32(dataPembimbing1.Rows[i]["id_dosen"]);
                string namaPembimbing1 = dataPembimbing1.Rows[i]["nama"].ToString();

                pembimbing1.Add(new KeyValuePair<int, string>(idPembimbing1, namaPembimbing1));
            }
            comboBox1.DataSource = pembimbing1;
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Value";


            DataTable dataPembimbing2 = DosenContext.all();
            List<KeyValuePair<int, string>> pembimbing2 = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataPembimbing2.Rows.Count; i++)
            {
                int idPembimbing2 = Convert.ToInt32(dataPembimbing1.Rows[i]["id_dosen"]);
                string namaPembimbing2 = dataPembimbing1.Rows[i]["nama"].ToString();

                pembimbing2.Add(new KeyValuePair<int, string>(idPembimbing2, namaPembimbing2));
            }
            comboBox2.DataSource = pembimbing2;
            comboBox2.ValueMember = "Value";
            comboBox2.DisplayMember = "Value";

            DataTable dataProdi = ProdiContext.all();
            List<KeyValuePair<int, string>> prodi1 = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataProdi.Rows.Count; i++)
            {
                int idProdi = Convert.ToInt32(dataProdi.Rows[i]["id_prodi"]);
                string namaProdi = dataProdi.Rows[i]["nama_prodi"].ToString();

                prodi1.Add(new KeyValuePair<int, string>(idProdi, namaProdi));
            }
            comboBox4.DataSource = prodi1;
            comboBox4.ValueMember = "Value";
            comboBox4.DisplayMember = "Value";
        }

        private void v_PengajuanSidangOperator_buttonPengajuanSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();
        }

        private void v_PengajuanSidangOperator_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_PengajuanSidangOperator_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_PengajuanSidangOperator_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_PengajuanSidangOperator_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_PengajuanSidangOperator_buttonAdministrasi_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_PengajuanSidangOperator_Load(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = PengajuanSidangSkripsiContext.all();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var nama = textBox1.Text;
            var nim = textBox9.Text;
            var judul = textBox5.Text;
            var transkrip_nilai = textBox7.Text;
            var bukti_orisinalitas = textBox8.Text;
            var bukti_acc = textBoxBuktiAcc_v_PengajuanSidangMahasiswa.Text;
            var file_skripsi = textBox6.Text;
            var no_telepon = textBox2.Text;



            KeyValuePair<int, string> selectedPembimbing1 = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            var pembimbing1 = selectedPembimbing1.Value;
            KeyValuePair<int, string> selectedPembimbing2 = (KeyValuePair<int, string>)comboBox2.SelectedItem;
            var pembimbing2 = selectedPembimbing2.Value;
            KeyValuePair<int, string> selectedProdi = (KeyValuePair<int, string>)comboBox4.SelectedItem;
            var prodi1 = selectedProdi.Value;
            KeyValuePair<int, string> selectedValidasi = (KeyValuePair<int, string>)comboBox3.SelectedItem;
            var status = selectedValidasi.Value;

            DialogResult message = MessageBox.Show("Apakah yakin ingin memvalidasi?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PengajuanSidangSkripsiContext.ubahPengajuan(id_pengajuan_sidang, nama, nim, judul, transkrip_nilai, file_skripsi, bukti_orisinalitas, bukti_acc, pembimbing1, pembimbing2, prodi1, status, no_telepon);
                MessageBox.Show("Berhasil Divalidasi", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = PengajuanSidangSkripsiContext.all();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_pengajuan_sidang = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox4.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBoxBuktiAcc_v_PengajuanSidangMahasiswa.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            comboBox3.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            comboBox2.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
        }
    }
}
