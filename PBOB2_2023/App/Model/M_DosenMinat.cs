using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBOB2_2023.App.Model
{
    internal class M_DosenMinat
    {
        [Key]
        public int id_dosen_minat { get; set; }
        [Required]
        public string nama { get; set; }
        public string minat {  get; set; }
        public string detail_minat { get; set; }
    }
}
