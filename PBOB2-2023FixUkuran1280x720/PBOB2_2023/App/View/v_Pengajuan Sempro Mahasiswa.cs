using PBOB2_2023.App.Context;
using PBOB2_2023.App.View;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Forms;
using PBOB2_2023.App.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBOB2_2023.View
{
    public partial class v_PengajuanSemproMahasiswa : Form
    {
        private string dateFormat = "dd/MM/yyyy";
        public v_PengajuanSemproMahasiswa()
        {
            InitializeComponent();
            // Looping untuk get Real Data dari DataTable
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
            for (int i = 0; i < dataPembimbing1.Rows.Count; i++)
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
            comboBox4.DataSource = prodi;
            comboBox4.ValueMember = "Value";
            comboBox4.DisplayMember = "Value";
        }

        private void v_PengajuanSemproMahasiswa_buttonPengajuanSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangMahasiswa().Show();
        }

        private void v_PengajuanSemproMahasiswa_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproMahasiswa().Show();
        }

        private void v_PengajuanSemproMahasiswa_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangMahasiswa().Show();
        }

        private void v_PengajuanSemproMahasiswa_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenMahasiswa().Show();
        }

        private void v_PengajuanSemproMahasiswa_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulMahasiswa().Show();
        }

        private void v_PengajuanSemproMahasiswa_buttonSimpan_Click(object sender, EventArgs e)
        {
            var nama = textBox1.Text;
            var nim = textBox9.Text;
            var judul = textBox2.Text;
            var rumusan_masalah = textBox3.Text;
            var topik = textBox4.Text;
            var tanggal_pengajuan = dateTimePicker1.Value.ToString(dateFormat);

            KeyValuePair<int, string> selectedPembimbing1 = (KeyValuePair<int, string>)comboBox2.SelectedItem;
            var pembimbing1 = selectedPembimbing1.Value;
            KeyValuePair<int, string> selectedPembimbing2 = (KeyValuePair<int, string>)comboBox2.SelectedItem;
            var pembimbing2 = selectedPembimbing2.Value;
            KeyValuePair<int, string> selectedProdi = (KeyValuePair<int, string>)comboBox4.SelectedItem;
            var prodi1 = selectedProdi.Value;


            var draft_proposal = textBox6.Text;
            var bukti_krs = textBox5.Text;
            var bukti_dosen_pembimbing = textBox7.Text;
            var total_sks = textBox8.Text;
            var status = "Belum Divalidasi";

            M_PengajuanSempro dataPengajuanSemrpoBaru = new M_PengajuanSempro
            {
                nama_mahasiswa = nama,
                nim = nim,
                judul_proposal = judul,
                topik = topik,
                rumusan_masalah = rumusan_masalah,
                tanggal_pengajuan = tanggal_pengajuan,
                draft_proposal = draft_proposal,
                bukti_krs = bukti_krs,
                bukti_dosen_pembimbing = bukti_dosen_pembimbing,
                pembimbing1 = pembimbing1,
                pembimbing2 = pembimbing2,
                status = status,
                prodi = prodi1,
                total_sks = total_sks,
            };
            DialogResult message = MessageBox.Show("Apakah yakin ingin menyimpan?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PengajuanSemproContext.store(dataPengajuanSemrpoBaru);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_PengajuanSemproMahasiswa_Load(object sender, EventArgs e)
        {

        }
    }
}
