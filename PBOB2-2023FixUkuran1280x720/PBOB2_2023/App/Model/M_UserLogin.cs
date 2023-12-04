using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBOB2_2023.App.Model
{
    internal class M_UserLogin
    {
        [Key]
        public int id_user_login { get; set; }
        [Required]
        public string username { get; set; }
        public string sandi { get; set; }
        public string peran { get; set; }
    }
}
