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
    [Table("m_table")]
    public class Tables
    {
        [Key]
        [Display(Name = "id")]
        public int TablesId { get; set; }

        [Required]
        [Column(TypeName = "VarChar(3)")]
        [Display(Name = "table_name")]
        public string TableName { get; set; }

        public virtual ICollection<Bills> Bills { get; set; }
    }
}
