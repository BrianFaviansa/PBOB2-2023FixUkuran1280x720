using System.ComponentModel.DataAnnotations;

namespace PBOB2_2023.App.Model
{
    internal class M_Prodi
    {
        [Key]
        public int id_prodi { get; set; }
        [Required]
        public string nama_prodi { get; set; }
    }
}
