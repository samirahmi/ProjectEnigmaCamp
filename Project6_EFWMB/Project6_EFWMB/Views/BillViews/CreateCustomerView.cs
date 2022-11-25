using Project6_EFWMB.Application.CustomerServices;
using Project6_EFWMB.Application.CustomerServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Views.BillViews
{
    public class CreateCustomerView
    {
        private ICustomerAppService _customerAppService;

        public CreateCustomerView(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        public void DisplayView()
        {
            Console.WriteLine("Create Customers");
            Console.WriteLine("--------------------------------");

            Console.Write("Customer Name    : ");
            string name = Console.ReadLine();
            Console.Write("Mobile Phone     : ");
            string phone = Console.ReadLine();
            Console.Write("Is Member? Y/N   : ");
            bool isMember = Console.ReadLine() == "Y";


            var createCustomer = new CreateCustomerDto()
            {
                CustomerName = name,
                MobilePhone = phone,
                IsMember = isMember
            };

            _customerAppService.Create(createCustomer);
            Console.WriteLine("New Customer Saved!!");
            Console.ReadKey();
        }
    }
}
