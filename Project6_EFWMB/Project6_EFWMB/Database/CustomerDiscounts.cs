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
    [Table("m_customer_discount")]
    public class CustomerDiscounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int CustDiscountsId { get; set; }

        [Display(Name = "disc_id")]
        public int? DiscountsId { get; set; }

        [Display(Name = "customer_id")]
        public int? CustomersId { get; set; }

        public virtual Discounts Discounts { get; set; }
        public virtual Customers Customers { get; set; }
    }
}
