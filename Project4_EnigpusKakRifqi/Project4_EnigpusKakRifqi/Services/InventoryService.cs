using Project4_EnigpusKakRifqi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_EnigpusKakRifqi.Services
{
    public class InventoryService : IInventoryService
    {
        //buat menyimpan
        private List<Book> _book = new List<Book>();

        public void AddBook(Book book)
        {
            //gak boleh ada title yang sama
            _book.Add(book);
        }

        public List<Book> GetAllBook()
        {
            return _book;
        }

        public List<Book> SearchBook(string title)
        {
            // 1. mencari - looping list nya
            // 2. consitionl untuk mencari book by title
            List<Book> searchListBook = new List<Book>(); // ini sebagai penampung

            foreach (var book in _book)
            {
                if (book.GetTitle().ToLower().Equals(title.ToLower()))
                {
                    searchListBook.Add(book);
                }
            }
            return searchListBook;
        }
    }
}
