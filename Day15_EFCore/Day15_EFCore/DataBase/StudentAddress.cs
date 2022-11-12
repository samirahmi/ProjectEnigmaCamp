using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15_EFCore.DataBase
{
    [Table("StudentAddresses", Schema = "dbo")]
    public class StudentAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Student Address Id")]
        public int StudentAddressId { get; set; }

        [Column(TypeName = "VarChar(200)")]
        [Display(Name = "Address 1")]
        public string? Address1 { get; set; }

        [Column(TypeName = "VarChar(200)")]
        [Display(Name = "Address 2")]
        public string? Address2 { get; set; }
        public string? Mobile { get; set; }
        public string Email { get; set; }
        public int StudentId { get; set; } //Foreign Key by default
        public virtual Student Student { get; set; } // Relation ke table Student
    }
}
