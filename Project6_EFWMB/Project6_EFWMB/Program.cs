using Microsoft.Extensions.DependencyInjection;
using Project6_EFWMB;
using Project6_EFWMB.Views.BillViews;
using Project6_EFWMB.Views.MenuViews;
using Project6_EFWMB.Views.ReportViews;
using Project6_EFWMB.Views.TableViews;

class Program
{
    static void Main()
    {
        Startup startup = new Startup();
        var menuView = startup.Provider.GetService<GetAllMenuView>();
        var tableView = startup.Provider.GetService<TableView>();
        var billView = startup.Provider.GetService<BillView>();
        var reportView = startup.Provider.GetService<ReportView>();

        bool showMenu = true;
        while (showMenu)
        {
            Console.Clear();
            Console.WriteLine("Welcome To 'Warung Makan Bahari'");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Choose an Option: ");
            Console.WriteLine("1) Menu");
            Console.WriteLine("2) Table");
            Console.WriteLine("3) Transaction");
            Console.WriteLine("4) Reports");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    menuView.DisplayView();
                    showMenu = true;
                    break;
                case "2":
                    tableView.DisplayView();
                    showMenu = true;
                    break;
                case "3":
                    billView.DisplayView();
                    showMenu = true;
                    break;
                case "4":
                    reportView.DisplayView();
                    showMenu = true;
                    break;
                case "5":
                    showMenu = false;
                    break;
                default:
                    showMenu = true;
                    break;
            }
        }
    }
}