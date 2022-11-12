using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Calculator
{
    abstract class Operation
    {
        public abstract int Add();
        public abstract int Subtract();
        public abstract int Multiply();
        public abstract double Divide();
    }

    class Calculator : Operation
    {
        InputUser input = new InputUser();

        public override int Add()
        {
            int a = input.Input1();
            int b = input.Input2();
            return a + b;
        }
        public override int Subtract()
        {
            int a = input.Input1();
            int b = input.Input2();
            return a - b;
        }
        public override int Multiply()
        {
            int a = input.Input1();
            int b = input.Input2();
            return a * b;
        }
        public override double Divide()
        {
            int a = input.Input1();
            int b = input.Input2();
            return a / b;
        }
    }
}
