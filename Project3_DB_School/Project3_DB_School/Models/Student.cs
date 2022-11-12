using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_DB_School.Models
{
    [Serializable]
    internal class Student
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
        public string Class { get; set; }

    }
}
