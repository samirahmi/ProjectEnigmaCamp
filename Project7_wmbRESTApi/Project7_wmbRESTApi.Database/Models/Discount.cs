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
    [Table("m_discount", Schema = "dbo")]
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int DiscountId { get; set; }

        [Column(TypeName = "VarChar(50)")]
        [Display(Name = "disc_desciption")]
        public string? DiscDesciption { get; set; }

        [Display(Name = "pct")]
        public int? Percent { get; set; }

        public virtual ICollection<CustomerDiscount> CustomerDiscounts { get; set; }
    }
}
