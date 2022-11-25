using Project6_EFWMB.Application.TableServices;
using Project6_EFWMB.Application.TableServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Views.TableViews
{
    public class UpdateTableView
    {
        private ITableAppService _tableAppService;

        public UpdateTableView(ITableAppService tableAppService)
        {
            _tableAppService = tableAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Update Table");
            Console.WriteLine("--------------------------------");
            Console.Write("Search Table Code (T01 - T30): ");
            string tableCode = Console.ReadLine();

            var table = _tableAppService.GetTableByCode(tableCode);
            if (table != null)
            {
                Console.WriteLine($"Table Id      : {table.TablesId}");
                Console.WriteLine($"Table Name    : {table.TableName}");
                Console.WriteLine($"Bill Id       : {table.BillsId}");

                Console.WriteLine("-----------------------------------------");
                Console.Write("Table Id      : ");
                int tableId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Table Name    : ");
                string tableName = Console.ReadLine();
                Console.Write("Bill Id       : ");
                int billId = Convert.ToInt32(Console.ReadLine());

                var tableDto = new UpdateTableDto();
                tableDto.TablesId = tableId;
                tableDto.TableName = tableName;
                tableDto.BillsId = billId;

                _tableAppService.Update(tableDto);
                Console.WriteLine("\nUpdate Success!!");
                Console.ReadKey();
            }
        }
    }
}
