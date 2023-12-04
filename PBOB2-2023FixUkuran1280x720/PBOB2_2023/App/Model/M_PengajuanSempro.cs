using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBOB2_2023.App.Model
{
    internal class M_PengajuanSempro
    {
        [Key]
        public int id_pengajuan_sempro { get; set; }
        [Required]
        public string nama_mahasiswa { get; set; }
        public string nim { get; set; }
        public string prodi { get; set; }
        public string total_sks { get; set; }
        public string judul_proposal { get; set; }
        public string tanggal_pengajuan { get; set; }
        public string rumusan_masalah { get; set; }
        public string draft_proposal { get; set; }
        public string bukti_krs { get; set; }
        public string bukti_dosen_pembimbing { get; set; }
        public string topik { get; set; }
        public string status { get; set; }
        public string pembimbing1 { get; set; }
        public string pembimbing2 { get; set; }

    }
}
