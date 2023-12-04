using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBOB2_2023.App.Model
{
    internal class M_PenjadwalanSidangSkripsi
    {
        [Key]
        public int id_jadwal_sidang { get; set; }
        [Required]
        public string nama_mahasiswa { get; set; }
        public string nim { get; set; }
        public string prodi { get; set; }
        public string tanggal { get; set; }
        public string jam { get; set; }
        public string ruang { get; set; }
        public string judul { get; set; }
        public string pembimbing1 { get; set; }
        public string pembimbing2 { get; set; }
        public string penguji1 { get; set; }
        public string penguji2 { get; set; }
        public string status {  get; set; }
    }
}
