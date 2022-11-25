using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project6_EFWMB.Application.BillServices.Dto
{
    public class BillListDto
    {
        public int BillsId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int CustomersId { get; set; }
        public string CustomerName { get; set; }
        public string TableName { get; set; }
        public string TransTypesId { get; set; }
    }
}
