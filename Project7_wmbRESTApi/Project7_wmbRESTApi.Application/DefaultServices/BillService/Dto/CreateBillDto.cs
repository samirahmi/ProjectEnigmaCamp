using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.BillService.Dto
{
    public class CreateBillDto
    {
        private string transtypeId;
        public int CustomerId { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public int TableId { get; set; }
        public string TransTypeId 
        { 
            get 
            { 
                return transtypeId; 
            } 
            set 
            {
                this.transtypeId = value.ToUpper(); 
            } 
        }
        public string IsPayment { get; set; }
    }
}
