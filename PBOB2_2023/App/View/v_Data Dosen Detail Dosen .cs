using PBOB2_2023.App.Context;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_DataDosenDosenDetail : Form
    {
        public v_DataDosenDosenDetail(string dataselected)
        {
            InitializeComponent();
            dataGridView1.DataSource = PengajuanSemproContext.alldetail(dataselected);
        }

        private void v_DataDosenDosenDetail_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproDosen().Show();
        }

        private void v_DataDosenDosenDetail_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangDosen().Show();
        }

        private void v_DataDosenDosenDetail_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulDosen().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_DataDosenDosenDetail_Load(object sender, System.EventArgs e)
        {
            
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenDosen().Show();
        }
    }
}
