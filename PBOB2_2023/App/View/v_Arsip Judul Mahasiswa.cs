using PBOB2_2023.App.Context;
using PBOB2_2023.App.View;
using System;
using System.Data;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_ArsipJudulMahasiswa : Form
    {
        public v_ArsipJudulMahasiswa()
        {
            InitializeComponent();
        }

        private void v_ArsipJudulMahasiswa_buttonPengajuanSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangMahasiswa().Show();
        }

        private void v_ArsipJudulMahasiswa_buttonPengajuanSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproMahasiswa().Show();
        }

        private void v_ArsipJudulMahasiswa_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproMahasiswa().Show();
        }

        private void v_ArsipJudulMahasiswa_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangMahasiswa().Show();
        }

        private void v_ArsipJudulMahasiswa_buttonDataDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenMahasiswa().Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_ArsipJudulMahasiswa_Load(object sender, EventArgs e)
        {
            DataTable arsipJudul = PengajuanSidangSkripsiContext.ArsipJudul("Disetujui");
            dataGridView1.DataSource = arsipJudul;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            DataTable searchResult = PenjadwalanSidangSkripsiContext.Search(keyword);
            dataGridView1.DataSource = searchResult;
        }
    }
}
