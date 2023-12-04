using PBOB2_2023.App.Context;
using System.Data;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_ArsipJudulDosen : Form
    {
        public v_ArsipJudulDosen()
        {
            InitializeComponent();
        }

        private void v_ArsipJudulDosen_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproDosen().Show();
        }

        private void v_ArsipJudulDosen_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangDosen().Show();
        }

        private void v_ArsipJudulDosen_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenDosen().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_ArsipJudulDosen_Load(object sender, System.EventArgs e)
        {
            DataTable arsipJudul = PengajuanSidangSkripsiContext.ArsipJudul("Disetujui");
            dataGridView1.DataSource = arsipJudul;
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            string keyword = textBox1.Text;
            DataTable searchResult = PenjadwalanSidangSkripsiContext.Search(keyword);
            dataGridView1.DataSource = searchResult;
        }
    }
}
