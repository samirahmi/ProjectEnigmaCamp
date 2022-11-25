using Project6_EFWMB.Application.TableServices;
using Project6_EFWMB.Application.TransactionServices;
using Project6_EFWMB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Views.BillViews
{
    public class GetAllBillView
    {
        private IBillAppService _billAppService;

        public GetAllBillView(IBillAppService billAppService)
        {
            _billAppService = billAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("List Of Bills");
            Console.WriteLine("--------------------------------");

            Console.Write("Enter Page      : ");
            int page = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Page Size : ");
            int pageSize = Convert.ToInt32(Console.ReadLine());

            var pageInfo = new PageInfo(page, pageSize);
            var billList = _billAppService.GetAllBills(pageInfo);

            decimal totalPage = billList.Total / pageSize;

            Console.WriteLine($"Display Page : {page} with total page : {(int)Math.Ceiling(totalPage)}");

            Console.WriteLine("BillId - Date - Name - TableCode - TransactionType");

            foreach (var b in billList.Data)
            {
                Console.WriteLine($"{b.BillsId} - {b.TransactionDate} - " +
                    $"{b.CustomerName} - {b.TableName} - {b.TransTypesId}");
            }

            Console.ReadKey();
        }
    }
}
