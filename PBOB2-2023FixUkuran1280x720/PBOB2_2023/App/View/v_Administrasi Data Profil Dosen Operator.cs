using PBOB2_2023.App.Context;
using PBOB2_2023.App.Model;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_AdministrasiDataProfilDosenOperator : Form
    {
        int id;
        public v_AdministrasiDataProfilDosenOperator()
        {
            InitializeComponent();
            dataGridView1.DataSource = DosenContext.all();

        }

        private void v_AdministrasiDataProfilDosenOperator_buttonPengajuanSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSidangOperator().Show();
        }

        private void v_AdministrasiDataProfilDosenOperator_buttonPengajuanSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_PengajuanSemproOperator().Show();

        }

        private void v_AdministrasiDataProfilDosenOperator_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproOperator().Show();
        }

        private void v_AdministrasiDataProfilDosenOperator_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangOperator().Show();
        }

        private void v_AdministrasiDataProfilDosenOperator_buttonDataDosen_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenOperator().Show();
        }

        private void v_AdministrasiDataProfilDosenOperator_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulOperator().Show();
        }

        private void v_AdministrasiDataProfilDosenOperator_buttonAdministrasi_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_AdministrasiOperator().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_AdministrasiDataProfilDosenOperator_Load(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = DosenContext.all();
        }

        private void button10_Click(object sender, System.EventArgs e)
        {
            var nama = textBox1.Text;
            var no_telepon = textBox2.Text;
            string username, sandi;
            int index = nama.IndexOf(' ');

            if (index != -1)
            {
                username = nama.Substring(0, index);
                sandi = username;
            }
            else
            {
                username = nama;
                sandi = username;
            }



            M_Dosen dataDosen = new M_Dosen()
            {
                nama = nama,
                no_telepon = no_telepon,
            };

            M_UserLogin datauser = new M_UserLogin()
            {
                username = username,
                sandi = sandi,
                peran = "Dosen"
            };
            DialogResult message = MessageBox.Show("Apakah yakin ingin menambah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                DosenContext.store(dataDosen);
                UserLoginContext.store(datauser);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = DosenContext.all();
            }
        }

        private void button11_Click(object sender, System.EventArgs e)
        {
            var nama = textBox1.Text;
            var no_telepon = textBox2.Text;

            DialogResult message = MessageBox.Show("Apakah yakin merubah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                DosenContext.updateOperator(id, nama, no_telepon);
                MessageBox.Show("Data berhasil dirubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = DosenContext.all();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button12_Click(object sender, System.EventArgs e)
        {
            DosenContext.destroy(id);
            DialogResult message = MessageBox.Show("Apakah yakin ingin menghapus data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
                MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = DosenContext.all();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
