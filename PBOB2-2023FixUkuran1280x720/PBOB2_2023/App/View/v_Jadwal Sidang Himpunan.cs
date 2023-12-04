using PBOB2_2023.App.Context;
using System;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_JadwalSidangHimpunan : Form
    {
        public v_JadwalSidangHimpunan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void v_JadwalSidangHimpunan_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproHimpunan().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_JadwalSidangHimpunan_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PenjadwalanSidangSkripsiContext.viewJadwalSidang();
        }
    }
}
