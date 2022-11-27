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
    [Table("m_customer", Schema = "dbo")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "id")]
        public int CustomerId { get; set; }

        [Required]
        [Column(TypeName = "VarChar(50)")]
        [Display(Name = "customer_name")]
        public string CustomerName { get; set; }

        [Required]
        [Column(TypeName = "VarChar(20)")]
        [Display(Name = "mobile_phone_no")]
        public string MobilePhone { get; set; }

        [Display(Name = "is_member")]
        public bool? IsMember { get; set; }

        public virtual ICollection<CustomerDiscount> CustomerDiscounts { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
