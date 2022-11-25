using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Database
{
    [Table("m_trans_type")]
    public class TransTypes
    {
        [Key]
        [Column(TypeName = "VarChar(3)")]
        [Display(Name = "trans_type_id")]
        public string TransTypesId { get; set; }

        [Column(TypeName = "VarChar(50)")]
        [Display(Name = "description")]
        public string? Description { get; set; }

        public virtual ICollection<Bills> Bills { get; set; }
    }
}
