using Project6_EFWMB.Application.CustomerServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.CustomerServices
{
    public interface ICustomerAppService
    {
        void Create(CreateCustomerDto model);
    }
}
