using PBOB2_2023.App.Context;
using System.Windows.Forms;

namespace PBOB2_2023.View
{
    public partial class v_JadwalSemproHimpunan : Form
    {
        int id_jadwal_sempro;
        public v_JadwalSemproHimpunan()
        {
            InitializeComponent();
        }

        private void v_JadwalSemproHimpunan_buttonJadwalSidang_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_JadwalSidangHimpunan().Show();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            new v_login().Show();
        }

        private void v_JadwalSemproHimpunan_Load(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = PenjadwalanSemproContext.viewJadwal();
        }

        private void button10_Click(object sender, System.EventArgs e)
        {
            var link_zoom = textboxMinat_v_operator.Text;
            var br_zoom = textboxDetailMinat_v_operator.Text;

            DialogResult message = MessageBox.Show("Apakah yakin ingin menambah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PenjadwalanSemproContext.ubahJadwal2(id_jadwal_sempro, link_zoom, br_zoom);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            dataGridView1.DataSource = PenjadwalanSemproContext.all();

        }

        private void button11_Click(object sender, System.EventArgs e)
        {
            var link_zoom = textboxMinat_v_operator.Text;
            var br_zoom = textboxDetailMinat_v_operator.Text;

            DialogResult message = MessageBox.Show("Apakah yakin ingin mengubah data?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                PenjadwalanSemproContext.ubahJadwal2(id_jadwal_sempro, link_zoom, br_zoom);
                MessageBox.Show("Data berhasil ditambahkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataGridView1.DataSource = PenjadwalanSemproContext.all();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_jadwal_sempro = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textboxMinat_v_operator.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textboxDetailMinat_v_operator.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }
    }
}
