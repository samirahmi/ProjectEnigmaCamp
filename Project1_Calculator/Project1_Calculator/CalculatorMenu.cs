using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Calculator
{
    public class CalculatorMenu
    {
        Calculator operation = new Calculator();
        InputUser user = new InputUser();
        public void MainMenu()
        {            
            var condition = true;
            while (condition)
            {
                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine("Choose an Operating System of Math");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Substract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");
                Console.WriteLine("==================================");
                Console.Write("Select an Option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        MenuAdd();
                        break;
                    case "2":
                        MenuSubstact();                        
                        break;
                    case "3":
                        MenuMultiply();
                        break;
                    case "4":
                        MenuDivide();
                        break;
                    case "5":
                        condition = false;
                        break;
                }
            }
        }

        private void MenuAdd()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("============================= Add ");
            Console.WriteLine($"a + b = {operation.Add()}");
            Console.WriteLine("==================================");
            Console.ReadKey();
        }

        private void MenuSubstact()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("======================== Substract");
            Console.WriteLine($"a - b = {operation.Subtract()}");
            Console.WriteLine("==================================");
            Console.ReadKey();
        }

        private void MenuMultiply()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("========================= Multiply");
            Console.WriteLine($"a x b = {operation.Multiply()}");
            Console.WriteLine("==================================");
            Console.ReadKey();
        }

        private void MenuDivide()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("=========================== Divide");
            Console.WriteLine($"a : b = {operation.Divide()}");
            Console.WriteLine("==================================");
            Console.ReadKey();
        }
    }
}
