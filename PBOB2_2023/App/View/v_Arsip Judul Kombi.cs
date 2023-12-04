using PBOB2_2023.App.Context;
using System.Data;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_ArsipJudulKombi : Form
    {
        public v_ArsipJudulKombi()
        {
            InitializeComponent();
            
        }

        private void v_ArsipJudulKombi_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproKombi().Show();
        }

        private void v_ArsipJudulKombi_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangKombi().Show();
        }

        private void v_ArsipJudulKombi_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenKombi().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_ArsipJudulKombi_Load(object sender, System.EventArgs e)
        {
            DataTable arsipJudul = PengajuanSidangSkripsiContext.ArsipJudul("Disetujui");
            dataGridView1.DataSource = arsipJudul;
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            string keyword = textBox1.Text;
            DataTable searchResult = PengajuanSidangSkripsiContext.Search(keyword);
            dataGridView1.DataSource = searchResult;
        }
    }
}
