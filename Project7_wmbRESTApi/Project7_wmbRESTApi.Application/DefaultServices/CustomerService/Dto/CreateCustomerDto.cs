﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.CustomerService.Dto
{
    public class CreateCustomerDto
    {
        public string CustomerName { get; set; }
        public string MobilePhone { get; set; }
        public bool IsMember { get; set; }
    }
}
