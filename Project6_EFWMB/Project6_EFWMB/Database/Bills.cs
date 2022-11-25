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
    [Table("t_bill")]
    public class Bills
    {
        [Key]
        [Display(Name = "id")]
        public int BillsId { get; set; }

        [Display(Name = "trans_date")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "customer_id")]
        public int CustomersId { get; set; }

        [Display(Name = "table_id")]
        public int? TablesId { get; set; }

        [Required]
        [Display(Name = "trans_type")]
        public string TransTypesId { get; set; }

        public virtual Customers Customers { get; set; }
        public virtual Tables Tables { get; set; }
        public virtual TransTypes TransTypes { get; set; }
        public virtual ICollection<BillDetails> BillDetails { get; set; }
    }
}
