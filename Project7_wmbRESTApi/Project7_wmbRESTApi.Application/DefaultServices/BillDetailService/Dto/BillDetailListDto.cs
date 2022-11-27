using Project7_wmbRESTApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.BillDetailService.Dto
{
    public class BillDetailListDto
    {
        public int BillId { get; set; }
        public DateTime BillDate { get; set; }
        public string CustomerName { get; set; }
        public string MenuName { get; set; }
        public float Price { get; set; }
        public float Qty { get; set; }
        public float Subtotal
        {
            get
            {
                return Qty * Price;
            }
            set
            {

            }
        }
        public string IsPayment { get; set; }

    }
}
