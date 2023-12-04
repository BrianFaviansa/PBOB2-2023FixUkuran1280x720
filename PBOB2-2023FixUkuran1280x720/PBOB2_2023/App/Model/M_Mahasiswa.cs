using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBOB2_2023.App.Model
{
    internal class M_Mahasiswa
    {
        [Key]
        public int id_mahasiswa { get; set; }
        [Required]
        public string nama { get; set; }
        public string nim { get; set; }
        public string no_telpon { get; set; }
        public string prodi { get; set; }
    }
}
