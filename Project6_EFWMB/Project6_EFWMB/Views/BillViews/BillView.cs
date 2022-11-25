using Microsoft.Extensions.DependencyInjection;
using Project6_EFWMB.Application.TransactionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Views.BillViews
{
    public class BillView
    {
        private IBillAppService _billAppService;
        public BillView(IBillAppService billAppService)
        {
            _billAppService = billAppService;
        }

        public void DisplayView()
        {
            Startup startup = new Startup();
            var cbView = startup.Provider.GetService<CreateBillView>();
            var gbView = startup.Provider.GetService<GetAllBillView>();
            var ccView = startup.Provider.GetService<CreateCustomerView>();

            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose an Option: ");
                Console.WriteLine("1) Create Customer");
                Console.WriteLine("2) Create Bills");
                Console.WriteLine("3) Get All Bills");
                Console.WriteLine("4) Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ccView.DisplayView();
                        showMenu = true;
                        break;
                    case "2":
                        cbView.DisplayView();
                        showMenu = true;
                        break;
                    case "3":
                        gbView.DisplayView();
                        showMenu = true;
                        break;
                    case "4":
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
