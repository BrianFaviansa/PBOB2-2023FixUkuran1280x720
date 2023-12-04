using PBOB2_2023.App.View;
using System;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_AdministrasiOperator : Form
    {
        public v_AdministrasiOperator()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void v_AdministrasiOperator_buttonPengajuanSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_AdministrasiOperator_buttonPengajuanSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();
        }

        private void v_AdministrasiOperator_buttonJadwalSempro_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_AdministrasiOperator_buttonJadwalSidang_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_AdministrasiOperator_buttonDataDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_AdministrasiOperator_buttonArsipJudul_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_AdministrasiOperator_buttonMenuDataProfilDosen_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_AdministrasiDataProfilDosenOperator().Show();
        }

        private void v_AdministrasiOperator_buttonMenuDataProfilMahasiswa_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_AdministrasiMahasiswaOperator().Show();
        }

        private void v_AdministrasiOperator_buttonMenuDataProfilHimpunan_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_AdministrasiHimpunanOperator().Show();
        }

        private void v_AdministrasiOperator_buttonMenuDataProgramStudi_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_AdministrasirogramStudiOperator().Show();
        }

        private void v_AdministrasiOperator_buttonMenuDataMinatPenelitian_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_AdministrasiDosenMinatOperator().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_AdministrasiOperator_buttonMenuUserLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new v_User_Login_Operator().Show();
        }
    }
}
