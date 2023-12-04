using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOB2_2023.App.Model
{
    internal class M_Himpunan
    {
        [Key]
        public int id_himpunan { get; set; }
        [Required]
        public string nama_himpunan { get; set; }
    }
}
