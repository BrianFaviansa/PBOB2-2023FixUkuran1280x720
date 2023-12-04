using PBOB2_2023.App.Context;
using PBOB2_2023.App.View;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_JadwalSidangMahasiswa : Form
    {
        public v_JadwalSidangMahasiswa()
        {
            InitializeComponent();
            dataGridView1.DataSource = PenjadwalanSidangSkripsiContext.all();
        }

        private void v_JadwalSidangMahasiswa_buttonPengajuanSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangMahasiswa().Show();
        }

        private void v_JadwalSidangMahasiswa_buttonPengajuanSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproMahasiswa().Show();
        }

        private void v_JadwalSidangMahasiswa_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproMahasiswa().Show();
        }

        private void v_JadwalSidangMahasiswa_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenMahasiswa().Show();
        }

        private void v_JadwalSidangMahasiswa_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulMahasiswa().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_JadwalSidangMahasiswa_Load(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = PenjadwalanSidangSkripsiContext.viewJadwalSidang();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {

        }
    }
}
