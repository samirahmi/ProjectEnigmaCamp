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
    [Table("m_customer_discount", Schema = "dbo")]
    public class CustomerDiscount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int CustDiscountId { get; set; }

        [Display(Name = "disc_id")]
        public int? DiscountId { get; set; }

        [Display(Name = "customer_id")]
        public int? CustomerId { get; set; }

        public virtual Discount Discounts { get; set; }
        public virtual Customer Customers { get; set; }
    }
}
