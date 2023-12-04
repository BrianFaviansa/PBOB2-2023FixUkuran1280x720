using PBOB2_2023.App.Context;
using PBOB2_2023.App.View;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_DataDosenOperator : Form
    {
        public string dataselected { get; private set; }
        public v_DataDosenOperator()
        {
            InitializeComponent();
            dataGridView1.DataSource = DosenContext.all();
        }

        private void v_Data_Dosen_Operator_buttonPengajuanSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_Data_Dosen_Operator_buttonPengajuanSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();
        }

        private void v_Data_Dosen_Operator_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_Data_Dosen_Operator_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_Data_Dosen_Operator_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_Data_Dosen_Operator_buttonAdministrasi_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_DataDosenOperator_Load(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = DosenContext.all();
        }

        private void button13_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenDetailMahasiswa(dataselected).Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataselected = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
