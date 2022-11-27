using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.TableService.Dto
{
    public class UpdateTableDto
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public int BillId { get; set; }
    }
}
