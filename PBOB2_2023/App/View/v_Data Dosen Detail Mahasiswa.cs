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
    public partial class v_DataDosenDetailMahasiswa : Form
    {
        public v_DataDosenDetailMahasiswa(string dataselected)
        {
            InitializeComponent();
            dataGridView1.DataSource = PengajuanSemproContext.alldetail(dataselected);
        }

        private void v_DataDosenDetailMahasiswa_buttonPengajuanSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangMahasiswa().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_DataDosenDetailMahasiswa_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = do
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulMahasiswa().Show();
        }

        private void v_DataDosenDetailMahasiswa_buttonPengajuanSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproMahasiswa().Show();
        }

        private void v_DataDosenDetailMahasiswa_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproMahasiswa().Show();
        }

        private void v_DataDosenDetailMahasiswa_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangMahasiswa() .Show();
        }

        private void v_DataDosenDetailMahasiswa_buttonDataDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenMahasiswa().Show();
        }
    }
}
