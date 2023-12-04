using PBOB2_2023.App.Context;
using PBOB2_2023.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBOB2_2023.App.View
{
    public partial class v_DataDosenDetailOperator : Form
    {
        public v_DataDosenDetailOperator(string dataselected)
        {
            InitializeComponent();
            dataGridView1.DataSource = PengajuanSemproContext.alldetail(dataselected);
        }

        private void v_Data_Dosen_Detail_Operator_buttonPengajuanSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_Data_Dosen_Detail_Operator_buttonPengajuanSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();
        }

        private void v_Data_Dosen_Detail_Operator_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_Data_Dosen_Detail_Operator_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_Data_Dosen_Detail_Operator_buttonDataDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_Data_Dosen_Detail_Operator_buttonArsipJudul_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_Data_Dosen_Detail_Operator_buttonAdministrasi_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
