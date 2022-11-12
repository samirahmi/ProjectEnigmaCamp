using DB_Library;
using Project4_DBLibrary.Interfaces;
using Project4_DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Project4_DBLibrary.DefaultServices
{
    internal class InventoryService : IInventoryService
    {
        private List<Novel> _novels = new List<Novel>();
        private List<Magazine> _magazines;

        public InventoryService(List<Novel> novels)
        {
            _novels = novels;
        }
        public InventoryService(List<Novel> novels, List<Magazine> magazines) : this(novels)
        {
            this._magazines = magazines;
        }

        public void AddBook()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Novel novel = new Novel();
                    Console.WriteLine("=====================");
                    Console.WriteLine("ADD NOVEL INFORMATION");
                    Console.WriteLine("=====================");
                    Console.WriteLine("Enter book code:");
                    string ncode = Console.ReadLine();
                    Console.WriteLine("Enter book title:");
                    string ntitle = Console.ReadLine();
                    Console.WriteLine("Enter book publisher:");
                    string npublis = Console.ReadLine();
                    Console.WriteLine("Enter book publication year:");
                    int nyear = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter book writer:");
                    string nwriter = Console.ReadLine();

                    novel.Code = ncode;
                    novel.Title = ntitle;
                    novel.Publisher = npublis;
                    novel.Year = nyear;
                    novel.Writer = nwriter;

                    _novels.Add(novel);

                    Console.ReadKey();

                    return;
                case 2:
                    Magazine magazine = new Magazine();
                    Console.WriteLine("========================");
                    Console.WriteLine("ADD MAGAZINE INFORMATION");
                    Console.WriteLine("========================");
                    Console.WriteLine("Enter book code:");
                    string mcode = Console.ReadLine();
                    Console.WriteLine("Enter book title:");
                    string mtitle = Console.ReadLine();
                    Console.WriteLine("Enter book publisher:");
                    string mpublis = Console.ReadLine();
                    Console.WriteLine("Enter book publication year:");
                    int myear = Convert.ToInt32(Console.ReadLine());

                    magazine.Code = mcode;
                    magazine.Title = mtitle;
                    magazine.Publisher = mpublis;
                    magazine.Year = myear;

                    _magazines.Add(magazine);

                    Console.ReadKey();

                    return;
                default:
                    Console.WriteLine("Wrong Number !!");
                    Console.WriteLine("Please Input the Book Type Number Again");
                    Console.ReadKey();
                    return;
            }
        }

        public void GetAllBook()
        {            
            Console.WriteLine("====================");
            Console.WriteLine("LIST OF ALL THE BOOK");
            Console.WriteLine("====================");

            foreach (var novel in _novels)
            {
                Console.WriteLine($"Type: Novel, code '{novel.Code}', Title '{novel.Title}', Publisher '{novel.Publisher}', Publication Year '{novel.Year}', Writer '{novel.Writer}'");
            }

            foreach (var magazine in _magazines)
            {
                Console.WriteLine($"Type: Magazine, code '{magazine.Code}', Title '{magazine.Title}', Publisher '{magazine.Publisher}', Publication Year '{magazine.Year}'");
            }

            Console.WriteLine("====================");

            Console.ReadKey();
        }

        public void SearchBook()
        {
            Novel novel = new Novel();
            Console.WriteLine("================================================");
            Console.WriteLine("Write the title of the book you're looking for: ");
            string noveltitle = (Console.ReadLine());

            novel.Title = noveltitle;
            int index = _novels.FindIndex(0, _novels.Count, w => w.Title == noveltitle);
            ////var targetnovel = _novels.FirstOrDefault(w => _novels.Contains(noveltitle));

            //Console.WriteLine($"Result of the book with the title: {noveltitle}");
            //Console.WriteLine($"Type: Novel, code '{novel.Code[index]}', Title '{_novels[index]}', Publisher '{_novels[index]}', Publication Year '{_novels[index]}', Writer '{_novels[index]}'");
            //Console.ReadKey();

            IEnumerable<Novel> findtitle = _novels.Where(novel => novel.Title == noveltitle).Select(novel => _novels[index]);
            foreach(var novels in findtitle)
            {
                List<Novel> listOffindtitle = findtitle.ToList();
            }

            Console.ReadKey();

            //BElumSIAP
            
        }
    }
}
