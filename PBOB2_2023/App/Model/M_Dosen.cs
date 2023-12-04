using System.ComponentModel.DataAnnotations;

namespace PBOB2_2023.App.Model
{
    internal class M_Dosen
    {
        [Key]
        public int id_dosen { get; set; }
        [Required]
        public string nama { get; set; }
        public string no_telepon { get; set; }
    }
}
