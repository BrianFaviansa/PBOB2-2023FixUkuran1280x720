using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBOB2_2023.App.Model
{
    internal class M_PengajuanSidangSkripsi
    {
        [Key]
        public int id_pengajuan_sidang { get; set; }
        [Required]
        public string nama_mahasiswa { get; set; }
        public string nim { get; set; }
        public string prodi { get; set; }
        public string judul { get; set; }
        public string file_skripsi { get; set; }
        public string transkrip_nilai { get; set; }
        public string bukti_acc { get; set; }
        public string bukti_orisinalitas { get; set; }
        public string status { get; set; }
        public string pembimbing1 { get; set; }
        public string pembimbing2 { get; set; }
        public string no_telepon { get; set; }
    }
}
