using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Calculator
{
    internal class InputUser
    {
        public int Input1()
        {
            int a = Convert.ToInt32(Console.ReadLine());
            return a;
            Console.ReadKey();
        }
        public int Input2()
        {
            int b = Convert.ToInt32(Console.ReadLine());
            return b;
            Console.ReadKey();
        }
    }
}
