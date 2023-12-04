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
    public partial class v_DataDosenMahasiswa : Form
    {
        public string dataselected { get; private set; }
        public v_DataDosenMahasiswa()
        {
            InitializeComponent();
            dataGridView1.DataSource = DosenContext.all();
        }


        private void v_DataDosenMahasiswa_buttonPengajuanSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangMahasiswa().Show();
        }

        private void v_DataDosenMahasiswa_buttonPengajuanSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproMahasiswa().Show();
        }

        private void v_DataDosenMahasiswa_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproMahasiswa().Show();
        }

        private void v_DataDosenMahasiswa_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangMahasiswa().Show();
        }

        private void v_DataDosenMahasiswa_buttonDataDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenMahasiswa().Show();
        }

        private void v_DataDosenMahasiswa_Load(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulMahasiswa().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenDetailMahasiswa(dataselected).Show();
        }

        private void v_DataDosenMahasiswa_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataselected = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
