using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.TransactionServices.Dto
{
    public class CreateBillDto
    {
        public int BillsId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int CustomersId { get; set; }
        public int TablesId { get; set; }
        public string TransTypesId { get; set; }
    }
}
