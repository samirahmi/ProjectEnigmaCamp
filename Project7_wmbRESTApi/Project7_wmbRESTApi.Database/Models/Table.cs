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
    [Table("m_table", Schema ="dbo")]
    public class Table
    {
        [Key]
        [Display(Name = "id")]
        public int TableId { get; set; }

        [Required]
        [Column(TypeName = "VarChar(3)")]
        [Display(Name = "table_name")]
        public string TableName { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
