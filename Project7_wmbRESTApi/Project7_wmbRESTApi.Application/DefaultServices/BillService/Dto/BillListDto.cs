using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.BillService.Dto
{
    public class BillListDto
    {
        public int BillId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CustomerName { get; set; }
        public string TableName { get; set; }
        public string TransTypeId { get; set; }
        public string IsPayment { get; set; }

    }
}
