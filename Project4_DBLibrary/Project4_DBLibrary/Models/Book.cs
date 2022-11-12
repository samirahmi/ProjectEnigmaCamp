using Project4_DBLibrary.DefaultServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project4_DBLibrary.Interfaces;

namespace Project4_DBLibrary.Models
{
    public abstract class Book
    {
        public abstract void GetTitle();
    }

    public class View : Book
    {
        public override void GetTitle()
        {
            Console.WriteLine("===============");
            Console.WriteLine("Enter Book Type");
            Console.WriteLine("===============");
            Console.WriteLine("1. Novel");
            Console.WriteLine("2. Magazine");
            Console.WriteLine("===============");
        }
    }
}
