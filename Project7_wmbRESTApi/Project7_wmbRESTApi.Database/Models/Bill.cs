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
    [Table("t_bill", Schema ="dbo")]
    public class Bill
    {
        [Key]
        [Display(Name = "id")]
        public int BillId { get; set; }

        [Display(Name = "trans_date")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "customer_id")]
        public int CustomerId { get; set; }

        [Display(Name = "table_id")]
        public int? TableId { get; set; }

        [Required]
        [Display(Name = "trans_type")]
        public string TransTypeId { get; set; }

        [Display(Name = "payment_status")]
        public string IsPayment { get; set; }

        public virtual Customer Customers { get; set; }
        public virtual Table Tables { get; set; }
        public virtual TransType TransTypes { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
