using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Views.TableViews
{
    public class TableView
    {

        public void DisplayView()
        {
            Startup startup = new Startup();
            var viewTable = startup.Provider.GetService<GetAllTableView>();
            var updateTable = startup.Provider.GetService<UpdateTableView>();

            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose an Option: ");
                Console.WriteLine("1) View All Table");
                Console.WriteLine("2) Update Table");
                Console.WriteLine("3) Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        viewTable.DisplayView();
                        showMenu = true;
                        break;
                    case "2":
                        updateTable.DisplayView();
                        showMenu = true;
                        break;
                    case "3":
                        showMenu = false;
                        break;
                    default:
                        showMenu = true;
                        break;
                }
            }
        }
    }
}
