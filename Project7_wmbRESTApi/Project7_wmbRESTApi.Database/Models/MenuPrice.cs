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
    [Table("m_menu_price", Schema ="dbo")]
    public class MenuPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int MenuPriceId { get; set; }

        [Display(Name = "menu_id")]
        public int MenuId { get; set; }

        [Required]
        [Column(TypeName = "Float4")]
        [Display(Name = "price")]
        public float Price { get; set; }

        public virtual Menu Menus { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }

    }
}
