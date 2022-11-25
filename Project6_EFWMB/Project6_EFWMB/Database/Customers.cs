using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Database
{
    [Table("m_customer")]
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int CustomersId { get; set; }

        [Required]
        [Column(TypeName = "VarChar(50)")]
        [Display(Name = "customer_name")]
        public string CustomerName { get; set; }

        [Required]
        [Column(TypeName = "VarChar(20)")]
        [Display(Name = "mobile_phone_no")]
        public string MobilePhone { get; set; }

        [Display(Name = "is_member")]
        public bool IsMember { get; set; }

        public virtual ICollection<CustomerDiscounts> CustomerDiscounts { get; set; }

        public virtual ICollection<Bills> Bills { get; set; }

    }
}
