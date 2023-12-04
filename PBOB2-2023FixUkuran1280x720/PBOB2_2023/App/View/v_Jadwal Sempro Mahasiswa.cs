using PBOB2_2023.App.Context;
using PBOB2_2023.App.View;
using System;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_JadwalSemproMahasiswa : Form
    {
        public v_JadwalSemproMahasiswa()
        {
            InitializeComponent();
        }

        private void v_JadwalSemproMahasiswa_buttonPengajuanSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangMahasiswa().Show();
        }

        private void v_JadwalSemproMahasiswa_buttonPengajuanSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproMahasiswa().Show();
        }

        private void v_JadwalSemproMahasiswa_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangMahasiswa().Show();
        }

        private void v_JadwalSemproMahasiswa_buttonDataDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenMahasiswa().Show();
        }

        private void v_JadwalSemproMahasiswa_buttonArsipJudul_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulMahasiswa().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_JadwalSemproMahasiswa_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PenjadwalanSemproContext.viewJadwal();
        }
    }
}
