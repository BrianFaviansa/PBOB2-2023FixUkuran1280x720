using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBOB2_2023.App.Model
{
    internal class M_Minat
    {
        [Key]
        public int id_minat { get; set; }
        [Required]
        public string minat { get; set; }
        public string detail_minat { get; set; }
    }
}
