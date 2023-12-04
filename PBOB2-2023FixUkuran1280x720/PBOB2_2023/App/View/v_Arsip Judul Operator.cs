using PBOB2_2023.App.Context;
using System.Data;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_ArsipJudulOperator : Form
    {
        public v_ArsipJudulOperator()
        {
            InitializeComponent();

            dataGridView1.DataSource = PenjadwalanSidangSkripsiContext.ArsipJudul("Disetujui");

        }

        private void v_ArsipJudulOperator_buttonPengajuanSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_ArsipJudulOperator_buttonPengajuanSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();
        }

        private void v_ArsipJudulOperator_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_ArsipJudulOperator_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_ArsipJudulOperator_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_ArsipJudulOperator_buttonDataAdministrasi_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_ArsipJudulOperator_Load(object sender, System.EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            string keyword = textBox1.Text;
            DataTable searchResult = PenjadwalanSidangSkripsiContext.Search(keyword);
            dataGridView1.DataSource = searchResult;

        }
    }
}
