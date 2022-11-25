using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Database
{
    [Table("m_menu_price")]
    public class MenuPrices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int MenuPricesId { get; set; }

        [Display(Name = "menu_id")]
        public int MenusId { get; set; }

        [Required]
        [Column(TypeName = "Float4")]
        [Display(Name = "price")]
        public float Price { get; set; }

        public virtual Menus Menus { get; set; }
        public virtual ICollection<BillDetails> BillDetails { get; set; }

    }
}
