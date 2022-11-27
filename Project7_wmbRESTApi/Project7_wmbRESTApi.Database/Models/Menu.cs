using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project7_wmbRESTApi.Database.Models
{
    [Table("m_menu", Schema = "dbo")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int MenuId { get; set; }

        [Required]
        [Column(TypeName = "VarChar(5)")]
        [Display(Name = "menu_code")]
        public string MenuCode { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        [Display(Name = "menu_name")]
        public string MenuName { get; set; }

        public virtual ICollection<MenuPrice> MenuPrices { get; set; }
    }
}
