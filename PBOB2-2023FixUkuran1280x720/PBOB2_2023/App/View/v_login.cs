using PBOB2_2023.App.Core;
using System;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_login : Form
    {
        public v_login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Get the username and password from the TextBoxes or other input controls
            string username = v_login_textboxUsername.Text;
            string sandi = v_login_textboxPassword.Text;

            // Call the Login method from CekLogin
            bool loginResult = CekLogin.Login(username, sandi);

            // You can perform further actions based on the login result
            if (loginResult)
            {
                this.Hide();
            }
            else
            {
                // If login fails, you might want to display an error message
                MessageBox.Show("Login gagal, harap cek username dan password", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
