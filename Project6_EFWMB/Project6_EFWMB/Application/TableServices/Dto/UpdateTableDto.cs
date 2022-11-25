using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.TableServices.Dto
{
    public class UpdateTableDto
    {
        public int TablesId { get; set; }
        public string TableName { get; set; }
        public int BillsId { get; set; }

    }
}
