using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project7_wmbRESTApi.Application.DefaultServices.BillDetailService.Dto
{
    public class CreateBillDetailDto
    {
        public int BillId { get; set; }
        public int MenuPriceId { get; set; }
        public float Qty { get; set; }
    }
}
