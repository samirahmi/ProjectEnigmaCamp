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
    [Table("m_discount")]
    public class Discounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int DiscountsId { get; set; }

        [Column(TypeName = "VarChar(50)")]
        [Display(Name = "disc_desciption")]
        public string? DiscDesciption { get; set; }

        [Display(Name = "pct")]
        public int? Percent { get; set; }

        public virtual ICollection<CustomerDiscounts> CustomerDiscounts { get; set; }
    }
}
