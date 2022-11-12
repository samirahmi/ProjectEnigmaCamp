using Project3_DB_School.DefaultServices;
using Project3_DB_School.Helpers;
using Project3_DB_School.Interfaces;
using Project3_DB_School.Models;

namespace DB_School
{
    class Program
    {
        private static List<Student> students = new List<Student>(); //Global Variabel
        static void Main()
        {
            bool showMenu = true;
            while(showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            IStudentService studentService = new StudentService(students);
            Helper helper = new Helper();

            Console.Clear();
            Console.WriteLine("Choose an Option");
            Console.WriteLine("=================");
            Console.WriteLine("1. Choose File School");
            Console.WriteLine("2. Delete File School");
            Console.WriteLine("3. Create Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Get All Student");
            Console.WriteLine("7. Exit");
            Console.Write("\r\nSelect an Option: ");

            switch(Console.ReadLine())
            {
                case "1":
                    helper.CreateFileSchool();
                    return true;
                case "3":
                    studentService.CreateStudent();
                    return true;
                case "4":
                    studentService.UpdateStudent();
                    return true;
                case "5":
                    studentService.DeleteStudent();
                    return true;
                case "6":
                    studentService.GetAllStudent();
                    return true;
                default:
                    return false;
            }
        }
    }
}