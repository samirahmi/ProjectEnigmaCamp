using Project7_wmbRESTApi.Application.DefaultServices.CustomerService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.CustomerService
{
    public interface ICustomerAppService
    {
        Task<(bool, string)> Create(CreateCustomerDto model);
        Task<(bool, string)> Update(UpdateCustomerDto model);

    }
}
