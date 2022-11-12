using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_DB_School.Models
{
    [Serializable]
    internal class Grade
    {        
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int Gradenum { get; set; }
        public char GradeType { get; set; }
    }
}
