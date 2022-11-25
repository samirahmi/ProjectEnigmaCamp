using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project6_EFWMB.Database
{
    [Table("m_menu")]
    public class Menus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int MenusId { get; set; }

        [Required]
        [Column(TypeName = "VarChar(10)")]
        [Display(Name = "menu_code")]
        public string MenuCode { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        [Display(Name = "menu_name")]
        public string MenuName { get; set; }

        public virtual ICollection<MenuPrices> MenuPrices { get; set; }
    }
}
