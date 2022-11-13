using Project4_EnigpusKakRifqi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_EnigpusKakRifqi.Services
{
    public interface IInventoryService
    {
        void AddBook(Book book);
        List<Book> SearchBook(string title);
        List<Book> GetAllBook();
    }
}
