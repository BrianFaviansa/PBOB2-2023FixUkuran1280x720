using PBOB2_2023.App.Context;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_DataDosenKombiBimbingan : Form
    {
        
        public int id_data_dosen_kombi;
        public string nama_dosen;

        public v_DataDosenKombiBimbingan(string nama_dosen)
        {
            InitializeComponent();
            dataGridView1.DataSource = PengajuanSemproContext.alldetail(nama_dosen);
            this.nama_dosen = nama_dosen;
        }

        private void v_DataDosenKombiBimbingan_buttonJadwalSempro_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSemproKombi().Show();

        }

        private void v_DataDosenKombiBimbingan_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangKombi().Show();
        }

        private void v_DataDosenKombiBimbingan_buttonArsipJudul_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_ArsipJudulKombi().Show();
        }

        private void button11_Click(object sender, System.EventArgs e)
        {
            PengajuanSemproContext.destroy(id_data_dosen_kombi);
            DialogResult message = MessageBox.Show("Apakah yakin ingin menghapus data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
                MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = PengajuanSemproContext.alldetail(nama_dosen);
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_DataDosenKombiBimbingan_Load(object sender, System.EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_data_dosen_kombi = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
         
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_DataDosenKombi().Show();
        }
    }
}
