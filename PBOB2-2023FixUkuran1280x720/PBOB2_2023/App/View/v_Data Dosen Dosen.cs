using PBOB2_2023.App.Context;
using System;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_DataDosenDosen : Form
    {
        public string dataselected { get; private set; }
        public v_DataDosenDosen()
        {
            InitializeComponent();
            dataGridView1.DataSource = DosenContext.all();
            
        }

        private void v_DataDosenDosen_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproDosen().Show();

        }

        private void v_DataDosenDosen_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangDosen().Show();
        }

        private void v_DataDosenDosen_buttonArsipJudul_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulDosen().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_DataDosenDosen_Load(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenDosenDetail(dataselected).Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataselected = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
