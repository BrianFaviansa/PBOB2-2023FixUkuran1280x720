using PBOB2_2023.App.Context;
using PBOB2_2023.App.Model;
using PBOB2_2023.App.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBOB2_2023.View
{
    public partial class v_PengajuanSidangMahasiswa : Form
    {
        public v_PengajuanSidangMahasiswa()
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
            v_PengajuanSidangMahasiswa_comboBoxPembimbing1.DataSource = pembimbing1;
            v_PengajuanSidangMahasiswa_comboBoxPembimbing1.ValueMember = "Value";
            v_PengajuanSidangMahasiswa_comboBoxPembimbing1.DisplayMember = "Value";


            DataTable dataPembimbing2 = DosenContext.all();
            List<KeyValuePair<int, string>> pembimbing2 = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataPembimbing2.Rows.Count; i++)
            {
                int idPembimbing2 = Convert.ToInt32(dataPembimbing1.Rows[i]["id_dosen"]);
                string namaPembimbing2 = dataPembimbing1.Rows[i]["nama"].ToString();

                pembimbing2.Add(new KeyValuePair<int, string>(idPembimbing2, namaPembimbing2));
            }
            v_PengajuanSidangMahasiswa_comboBoxPembimbing2.DataSource = pembimbing2;
            v_PengajuanSidangMahasiswa_comboBoxPembimbing2.ValueMember = "Value";
            v_PengajuanSidangMahasiswa_comboBoxPembimbing2.DisplayMember = "Value";

            DataTable dataProdi = ProdiContext.all();
            List<KeyValuePair<int, string>> prodi1 = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dataProdi.Rows.Count; i++)
            {
                int idProdi = Convert.ToInt32(dataProdi.Rows[i]["id_prodi"]);
                string namaProdi = dataProdi.Rows[i]["nama_prodi"].ToString();

                prodi1.Add(new KeyValuePair<int, string>(idProdi, namaProdi));
            }
            comboBox1.DataSource = prodi1;
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Value";

        }

        private void v_PengajuanSidangMahasiswaButtonSimpan_Click(object sender, EventArgs e)
        {
            var nama = textBoxNama_v_PengajuanSidangMahasiswa.Text;
            var nim = textBoxNIM.Text;
            var no_telepon = textBoxNoTelpon_v_PengajuanSidangMahasiswa.Text;
            var judul = textBoxJudul_v_PengajuanSidangMahasiswa.Text;
            KeyValuePair<int, string> selectedPembimbing1 = (KeyValuePair<int, string>)v_PengajuanSidangMahasiswa_comboBoxPembimbing1.SelectedItem;
            var pembimbing1 = selectedPembimbing1.Value;
            KeyValuePair<int, string> selectedPembimbing2 = (KeyValuePair<int, string>)v_PengajuanSidangMahasiswa_comboBoxPembimbing2.SelectedItem;
            var pembimbing2 = selectedPembimbing2.Value;
            KeyValuePair<int, string> selectedProdi = (KeyValuePair<int, string>)comboBox1.SelectedItem;
            var prodi1 = selectedProdi.Value;
            var transkrip = textBoxBuktiOri_v_PengajuanSidangMahasiswa.Text;
            var bukti_orisinalitas = textBoxBuktiAcc_v_PengajuanSidangMahasiswa.Text;
            var bukti_acc = textBoxBuktiAcc_v_PengajuanSidangMahasiswa.Text;
            var file_skripsi = textBox1.Text;

            M_PengajuanSidangSkripsi dataPengajuanSidangSkripsi = new M_PengajuanSidangSkripsi
            {
                nama_mahasiswa = nama,
                nim = nim,
                no_telepon = no_telepon,
                judul = judul,
                pembimbing1 = pembimbing1,
                pembimbing2 = pembimbing2,
                transkrip_nilai = transkrip,
                bukti_acc = bukti_acc,
                bukti_orisinalitas = bukti_orisinalitas,
                prodi = prodi1,
                file_skripsi = file_skripsi,
                status = "Tidak Disetujui",


            };
            DialogResult message = MessageBox.Show("Apakah yakin ingin menyimpan?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PengajuanSidangSkripsiContext.store(dataPengajuanSidangSkripsi);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void v_PengajuanSidangMahasiswa_buttonPengajuanSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproMahasiswa().Show();
        }

        private void v_PengajuanSidangMahasiswa_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproMahasiswa().Show();
        }

        private void v_PengajuanSidangMahasiswa_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangMahasiswa().Show();
        }

        private void v_PengajuanSidangMahasiswa_buttonDataDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenMahasiswa().Show();
        }

        private void v_PengajuanSidangMahasiswa_buttonArsipJudul_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulMahasiswa().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_PengajuanSidangMahasiswa_Load(object sender, EventArgs e)
        {

        }
    }
}
