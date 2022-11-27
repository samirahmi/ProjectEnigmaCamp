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
    [Table("m_trans_type", Schema = "dbo")]
    public class TransType
    {
        [Key]
        [Column(TypeName = "VarChar(3)")]
        [Display(Name = "trans_type_id")]
        public string TransTypeId { get; set; }

        [Column(TypeName = "VarChar(50)")]
        [Display(Name = "description")]
        public string? Description { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
