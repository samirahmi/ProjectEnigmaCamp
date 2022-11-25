using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project6_EFWMB.Application.CustomerServices.Dto
{
    public class CreateCustomerDto
    {
        public string CustomerName { get; set; }
        public string MobilePhone { get; set; }
        public bool IsMember { get; set; }
    }
}
