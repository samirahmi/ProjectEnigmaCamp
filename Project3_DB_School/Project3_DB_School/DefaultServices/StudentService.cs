using Project3_DB_School.Helpers;
using Project3_DB_School.Interfaces;
using Project3_DB_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_DB_School.DefaultServices
{
    internal class StudentService : IStudentService
    {
        private List<Student> _students = new List<Student>(); //Global Variabel
        public StudentService(List<Student> students) //Default Constractor
        {
            _students = students;
        }
        public void CreateStudent()
        {
            var helper = new Helper();
            var schoolContext = helper.OpenFile();

            Student student = new Student();
            Console.WriteLine("\nInput Data Student");
            Console.WriteLine("----------------------");
            Console.Write("Id Student   : ");
            int idStudent = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name Student : ");
            string nameStudent = Console.ReadLine();

            student.Id = idStudent;
            student.Name = nameStudent;

            //_students.Add(student);
            schoolContext.students.Add(student); //save ke file

            Console.ReadKey();
        }

        public void DeleteStudent()
        {
            Student student = new Student();
            Console.WriteLine("\nDelete Student");
            Console.WriteLine("----------------------");
            Console.Write("Choose a character to delete, by Id: ");
            int studentsid = Convert.ToInt32(Console.ReadLine());

            student.Id = studentsid;
            //int index = _students.FindIndex(0, _students.Count, w => w.Id == studentsid);
            //_students.RemoveAt(index);

            _students.RemoveAt(student.Id);

            Console.WriteLine("\nThe character was deleted");

            Console.ReadKey();
        }

        public void GetAllStudent()
        {
            var helper = new Helper();
            var schoolContext = helper.OpenFile();

            foreach (var student in schoolContext.students)
            {
                Console.WriteLine($"{student.Id} - {student.Name}");
            }

            Console.ReadKey();
        }

        public void UpdateStudent()
        {
            Student student = new Student();
            Console.WriteLine("\nUpdate Student");
            Console.WriteLine("----------------------");
            Console.Write("Id Student   : ");
            int idStudent = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name Student : ");
            string nameStudent = Console.ReadLine();

            student.Id = idStudent;
            student.Name = nameStudent;

            _students.Insert(_students.Count, student);

            Console.ReadKey();
        }
    }
}
