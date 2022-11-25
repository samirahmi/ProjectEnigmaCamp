using Project6_EFWMB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Views.ReportViews
{
    public class ReportView
    {
        private WarungContext _warungContext;
        public ReportView(WarungContext warungContext)
        {
            _warungContext = warungContext;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("List Of Bill Details");
            Console.WriteLine("--------------------------------");
            var Data = from a in _warungContext.Tables
                       join b in _warungContext.Bills
                            on a.TablesId equals b.TablesId
                       join c in _warungContext.BillDetails
                            on b.BillsId equals c.BillsId
                       join d in _warungContext.Customers
                            on b.CustomersId equals d.CustomersId
                       select new
                       {
                           Date = b.TransactionDate,
                           Table = a.TableName,
                           Name = d.CustomerName,
                           Qty = c.Qty,
                           Price = c.TotalPrice
                       };

            foreach(var rv in Data)
            {
                Console.WriteLine($"{rv.Date} - {rv.Table} - {rv.Name} - {rv.Qty} - {rv.Price}");
            }

            Console.ReadKey();
        }
    }
}
