//using Project4_DBLibrary.Interfaces;
//using Project4_DBLibrary.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Project4_DBLibrary.DefaultServices
//{
//    internal class NovelInventoryService : INovelInventoryService
//    {
//        private List<Novel> _novel = new List<Novel>();

//        public NovelInventoryService(List<Novel> novel)
//        {
//            _novel = novel;
//        }

//        public void AddNovel()
//        {
//            INovelInventoryService inventoryService = new NovelInventoryService(_novel);
//            Novel novel = new Novel();

//            Console.WriteLine("=====================");
//            Console.WriteLine("ADD NOVEL INFORMATION");
//            Console.WriteLine("=====================");
//            Console.WriteLine("Enter book code:");
//            string bookcode_n = Console.ReadLine();
//            Console.WriteLine("Enter book title:");
//            string booktitle_n = Console.ReadLine();
//            Console.WriteLine("Enter book publisher:");
//            string bookpublis_n = Console.ReadLine();
//            Console.WriteLine("Enter book publication year:");
//            int bookyear_n = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Enter book writer:");
//            string bookwriter_n = Console.ReadLine();

//            novel.Code = bookcode_n;
//            novel.Title = booktitle_n;
//            novel.Publisher = bookpublis_n;
//            novel.Year = bookyear_n;
//            novel.Writer = bookwriter_n;

//            _novel.Add(novel);

//            Console.ReadKey();
//        }

//        public void GetAllNovel()
//        {
//            Console.WriteLine("====================");
//            Console.WriteLine("LIST OF ALL THE BOOK");
//            Console.WriteLine("====================");
//            foreach (var novel in _novel)
//            {
//                Console.WriteLine($"Type: Novel, code '{novel.Code}', Title '{novel.Title}', Publisher '{novel.Publisher}', Publication Year '{novel.Year}', Writer '{novel.Writer}'");
//            }
//            throw new NotImplementedException();
//        }

//        public void SearchNovel()
//        {
//            Novel novel = new Novel();
//            Console.WriteLine("====================");
//            Console.WriteLine("Write the title of the book you're looking for: ");
//            string booktitle = (Console.ReadLine());

//            novel.Title = booktitle;
//            int index = _novel.FindIndex(0, _novel.Count, w => w.Title == booktitle);

//            Console.WriteLine($"Result of the book with the title: {booktitle}");
//        }
//    }
//}
