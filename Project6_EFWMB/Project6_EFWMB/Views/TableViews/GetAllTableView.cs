using Project6_EFWMB.Application.TableServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Views.TableViews
{
    public class GetAllTableView
    {
        private ITableAppService _tableAppService;

        public GetAllTableView(ITableAppService tableAppService)
        {
            _tableAppService = tableAppService;
        }

        public void DisplayView()
        {
            Console.WriteLine("List of Table\n");

            var tableList = _tableAppService.GetAllTable();
            foreach (var t in tableList)
            {
                Console.WriteLine($"{t.TablesId} - {t.TableName} - {t.BillsId}");
            }

            Console.ReadLine();
        }
    }
}
