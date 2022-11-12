using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_DB_School.Models
{
    [Serializable]
    internal class SchoolContext
    {
        public List<Student> students = new List<Student>();
        public List<Grade> grades = new List<Grade>();
    }
}
