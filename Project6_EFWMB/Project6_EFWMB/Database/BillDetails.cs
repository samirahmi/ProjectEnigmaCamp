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
    [Table("t_bill_detail")]
    public class BillDetails
    {
        [Key]
        [Display(Name = "id")]
        public int BillDetailsId { get; set; }

        [Display(Name = "bill_id")]
        public int BillsId { get; set; }

        [Display(Name = "menu_price_id")]
        public int MenuPricesId { get; set; }

        [Required]
        [Column(TypeName = "Float4")]
        [Display(Name = "qty")]
        public float Qty { get; set; }

        [Display(Name = "total_price")]
        public int TotalPrice { get; set; }

        public virtual Bills Bills { get; set; }
        public virtual MenuPrices MenuPrices { get; set; }
    }
}
