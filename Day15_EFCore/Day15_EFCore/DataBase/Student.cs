using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.Mime;

namespace Day15_EFCore.DataBase
{
    // ini merupakan model dari object student yang akan di tampung ke ShcoollDb
    [Table("Students", Schema = "dbo")]
    public class Student
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto increament
        [Display(Name = "Student Id")]
        public int StudentId { get; set; } // by default 32bit

        [Required] // Not Null
        [Column(TypeName = "VarChar(20)")] // lengt string sepanjang 20 karakter
        [Display(Name = "Student Code")]
        public string StudentCode { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        //[Column(TypeName = "VarChar(200)")]
        //[Display(Name = "Address")]
        //public string? Address { get; set; } // Menambahkan Field Baru // string? = nullable (boleh kosong)
        public DateTime? DoB { get; set; }
        public byte? Gender { get; set; }
        public virtual StudentAddress StudentAddress { get; set; }
    }
}
