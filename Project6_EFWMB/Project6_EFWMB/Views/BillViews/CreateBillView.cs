using Project6_EFWMB.Application.BillDetailServices;
using Project6_EFWMB.Application.BillDetailServices.Dto;
using Project6_EFWMB.Application.MenuServices;
using Project6_EFWMB.Application.TableServices;
using Project6_EFWMB.Application.TransactionServices;
using Project6_EFWMB.Application.TransactionServices.Dto;
using Project6_EFWMB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Views.BillViews
{
    public class CreateBillView
    {
        private IBillAppService _billAppService;
        private ITableAppService _tableAppService;
        private IMenuAppService _menuAppService;
        private IBillDetailAppService _billDetailAppService;

        public CreateBillView(IBillAppService billAppService,
            ITableAppService tableAppService,
            IMenuAppService menuAppService,
            IBillDetailAppService billDetailAppService)
        {
            _billAppService = billAppService;
            _tableAppService = tableAppService;
            _menuAppService = menuAppService;
            _billDetailAppService = billDetailAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Create Bills");
            Console.WriteLine("--------------------------------");

            Console.Write("Bill Id           : ");
            int billId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Customer Id       : ");
            int cusId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("----------------------------");
            Console.WriteLine("Transaction Type = DI / TA ?");
            Console.Write("Transaction Type  : ");
            string transtype = Console.ReadLine();

            Console.WriteLine("\n----------------------------");
            Console.WriteLine("DI = Table Code T02 - T30");
            Console.WriteLine("TA = Table Code T01");
            Console.WriteLine("----------------------------");
            Console.Write("Table Code        : ");
            string tablecode =Console.ReadLine();
            var tableId = _tableAppService.GetTableByCode(tablecode);

            var createBill = new CreateBillDto()
            {
                BillsId = billId,
                TransactionDate = DateTime.UtcNow,
                CustomersId = cusId,
                TablesId = tableId.TablesId,
                TransTypesId = transtype
            };

            _billAppService.Create(createBill);
            var total = 0;
            
            bool repeat = true;
            while (repeat)
            {
                Console.Write("\nMasukkan Menu     : ");
                int code = Convert.ToInt32(Console.ReadLine());
                var menu = _menuAppService.GetMenuByCode(code);
                Console.Write("Masukkan Qty      : ");
                int qty = Convert.ToInt32(Console.ReadLine());
                float subtotal = menu.Price * qty;
                total = (int)(total + subtotal);

                var billsDetail = new CreateBillDetailDto();
                billsDetail.BillsId = billId;
                billsDetail.MenuPricesId = menu.MenuPricesId;
                billsDetail.Qty = qty;
                billsDetail.TotalPrice = total;

                _billDetailAppService.Create(billsDetail);

                Console.WriteLine($"Total Price {total}");

                Console.Write("\nDo You Want to Create Transaction Again? (Y/N)? : ");
                string choise = Console.ReadLine();

                if (choise.ToUpper().Equals("Y"))
                    repeat = true;
                else
                    repeat = false;
            }

            Console.WriteLine("Record Save!!");
            Console.ReadKey();
        }
    }
}
