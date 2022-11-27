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
    [Table("t_bill_detail", Schema = "dbo")]
    public class BillDetail
    {
        [Key]
        [Display(Name = "id")]
        public int BillDetailId { get; set; }

        [Display(Name = "bill_id")]
        public int BillId { get; set; }

        [Display(Name = "menu_price_id")]
        public int MenuPriceId { get; set; }

        [Required]
        [Column(TypeName = "Float4")]
        [Display(Name = "qty")]
        public float Qty { get; set; }

        public virtual Bill Bills { get; set; }
        public virtual MenuPrice MenuPrices { get; set; }
    }
}
