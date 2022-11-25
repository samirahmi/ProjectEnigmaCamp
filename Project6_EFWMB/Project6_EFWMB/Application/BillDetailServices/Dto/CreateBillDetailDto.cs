using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project6_EFWMB.Application.BillDetailServices.Dto
{
    public class CreateBillDetailDto
    {
        public int BillsId { get; set; }
        public int MenuPricesId { get; set; }
        public float Qty { get; set; }
        public int TotalPrice { get; set; }
    }
}
