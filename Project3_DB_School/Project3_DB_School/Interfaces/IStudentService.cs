using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_DB_School.Interfaces
{
    internal interface IStudentService
    {
        void CreateStudent();
        void UpdateStudent();
        void DeleteStudent();
        void GetAllStudent();
    }
}
