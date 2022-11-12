using Project4_DBLibrary.DefaultServices;
using Project4_DBLibrary.Interfaces;
using Project4_DBLibrary.Models;

namespace DB_Library
{
    class Program
    {
        private static List<Novel> novels = new List<Novel>();
        private static List<Magazine> magazines = new List<Magazine>();

        static void Main()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            View bookview = new View();

            IInventoryService inventoryService = new InventoryService(novels, magazines);

            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("======== WELCOME TO ENIGPUS INVENTORY ========");
            Console.WriteLine("==============================================");
            Console.WriteLine("Select the menu below:");
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. View the book list");
            Console.WriteLine("3. Search book by title");
            Console.WriteLine("4. Exit the app");
            Console.WriteLine("==============================================");

            switch(Console.ReadLine())
            {
                case "1":
                    
                    bookview.GetTitle();
                    inventoryService.AddBook();
                    return true;
                case "2":
                    inventoryService.GetAllBook();
                    return true;
                case "3":
                    inventoryService.SearchBook();
                    return true;
                default:
                    Console.Clear();
                    Console.WriteLine("THANK YOU!!");
                    return false;
                    break;
            }
        }
    }
}