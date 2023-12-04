using PBOB2_2023.App.Context;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Forms;
using PBOB2_2023.App.Model;
using System.Security.Cryptography;

namespace PBOB2_2023.View
{
    public partial class v_JadwalSidangOperator : Form
    {
        int id_jadwal_sidang;
        private string dateFormat = "dd/MM/yyyy";

        public v_JadwalSidangOperator()
        {
            InitializeComponent();

            dataGridView1.DataSource = PenjadwalanSidangSkripsiContext.all();

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
                int idPembimbing2 = Convert.ToInt32(dataPembimbing2.Rows[i]["id_dosen"]);
                string namaPembimbing2 = dataPembimbing2.Rows[i]["nama"].ToString();

                pembimbing2.Add(new KeyValuePair<int, string>(idPembimbing2, namaPembimbing2));
            }
            comboBox2.DataSource = pembimbing2;
            comboBox2.ValueMember = "Value";
            comboBox2.DisplayMember = "Value";

            DataTable dataProdi = ProdiContext.all();
            List<KeyValuePair<int, string>> prodi = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataProdi.Rows.Count; i++)
            {
                int idProdi = Convert.ToInt32(dataProdi.Rows[i]["id_prodi"]);
                string namaProdi = dataProdi.Rows[i]["nama_prodi"].ToString();

                prodi.Add(new KeyValuePair<int, string>(idProdi, namaProdi));
            }
            comboBox3.DataSource = prodi;
            comboBox3.ValueMember = "Value";
            comboBox3.DisplayMember = "Value";

        }

        private void v_JadwalSidangOperator_buttonPengajuanSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_JadwalSidangOperator_buttonPengajuanSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();
        }

        private void v_JadwalSidangOperator_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_JadwalSidangOperator_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_JadwalSidangOperator_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_JadwalSidangOperator_buttonAdministrasi_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_JadwalSidangOperator_Load(object sender, System.EventArgs e)
        {

        }

        

        private void button11_Click(object sender, EventArgs e)
        {
            var nama_mahasiswa = textBox1.Text;
            var nim = textBox9.Text;
            KeyValuePair<int, string> selectedProdi = (KeyValuePair<int, string>)comboBox3.SelectedItem;
            var prodi = selectedProdi.Value;
            var tanggal = dateTimePicker1.Value.ToString(dateFormat);
            var jam = textBox3.Text;
            var ruang = textBox2.Text;
            var judul = textBox4.Text;
            KeyValuePair<int, string> selectedPembimbing1 = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            var pembimbing1 = selectedPembimbing1.Value;
            KeyValuePair<int, string> selectedPembimbing2 = (KeyValuePair<int, string>)comboBox2.SelectedItem;
            var pembimbing2 = selectedPembimbing2.Value;

            DialogResult message = MessageBox.Show("Apakah yakin ingin menyimpan?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PenjadwalanSemproContext.ubahJadwal(id_jadwal_sidang, nama_mahasiswa, nim, prodi, tanggal, jam, judul, ruang, pembimbing1, pembimbing2);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataGridView1.DataSource = PenjadwalanSemproContext.all();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_jadwal_sidang = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox3.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            object valueTanggal = dataGridView1.Rows[e.RowIndex].Cells[4].Value;
            DateTime.TryParse(valueTanggal.ToString(), out DateTime result);
            dateTimePicker1.Value = result;
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            comboBox2.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var nama_mahasiswa = textBox1.Text;
            var tanggal = dateTimePicker1.Value.ToString(dateFormat);
            var judul = textBox4.Text;
            var nim = textBox9.Text;
            var ruang = textBox2.Text;
            var jam = textBox3.Text;
            KeyValuePair<int, string> selectedPembimbing1 = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            var pembimbing1 = selectedPembimbing1.Value;
            KeyValuePair<int, string> selectedPembimbing2 = (KeyValuePair<int, string>)comboBox2.SelectedItem;
            var pembimbing2 = selectedPembimbing2.Value;
            KeyValuePair<int, string> selectedProdi = (KeyValuePair<int, string>)comboBox3.SelectedItem;
            var prodi = selectedProdi.Value;

            M_PenjadwalanSidangSkripsi PenjadwalanSidangSkripsiBaru = new M_PenjadwalanSidangSkripsi
            {
                nama_mahasiswa = nama_mahasiswa,
                nim = nim,
                jam = jam,
                tanggal = tanggal,
                judul = judul,
                ruang = ruang,
                pembimbing1 = pembimbing1,
                pembimbing2 = pembimbing2,
                penguji1 = "-",
                penguji2 = "-",
                prodi = prodi,
                status = "-"
            };
            DialogResult message = MessageBox.Show("Apakah yakin ingin menyimpan?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PenjadwalanSidangSkripsiContext.store(PenjadwalanSidangSkripsiBaru);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataGridView1.DataSource = PenjadwalanSidangSkripsiContext.all();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            var nama_mahasiswa = textBox1.Text;
            var nim = textBox9.Text;
            KeyValuePair<int, string> selectedProdi = (KeyValuePair<int, string>)comboBox3.SelectedItem;
            var prodi = selectedProdi.Value;
            var tanggal = dateTimePicker1.Value.ToString(dateFormat);
            var jam = textBox3.Text;
            var ruang = textBox2.Text;
            var judul = textBox4.Text;
            KeyValuePair<int, string> selectedPembimbing1 = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            var pembimbing1 = selectedPembimbing1.Value;
            KeyValuePair<int, string> selectedPembimbing2 = (KeyValuePair<int, string>)comboBox2.SelectedItem;
            var pembimbing2 = selectedPembimbing2.Value;

            DialogResult message = MessageBox.Show("Apakah yakin ingin menyimpan?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PenjadwalanSidangSkripsiContext.ubahJadwal(id_jadwal_sidang, nama_mahasiswa, nim, prodi, tanggal, jam, judul, ruang, pembimbing1, pembimbing2);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataGridView1.DataSource = PenjadwalanSidangSkripsiContext.all();

        }
    }
}