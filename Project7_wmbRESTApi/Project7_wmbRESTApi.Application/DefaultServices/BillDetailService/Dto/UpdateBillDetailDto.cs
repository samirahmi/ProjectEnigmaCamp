using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.BillDetailService.Dto
{
    public class UpdateBillDetailDto
    {
        public int BillDetailId { get; set; }
        public int BillId { get; set; }
        public int MenuPriceId { get; set; }
        public float Qty { get; set; }
    }
}
