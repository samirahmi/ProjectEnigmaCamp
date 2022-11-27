using AutoMapper.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project7_wmbRESTApi.Application.DefaultServices.CustomerService;
using Project7_wmbRESTApi.Application.DefaultServices.CustomerService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using Project7_wmbRESTApi.Application.Model;

namespace Project7_wmbRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;
        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpPost("SaveCustomer")]
        [Authorize]
        public async Task<IActionResult> SaveCustomer([FromBody] CreateCustomerDto model)
        {
            try
            {
                var (isAdded, isMessage) = await _customerAppService.Create(model);
                if (!isAdded)
                {
                    return Requests.Response(this, new ApiStatus(406), isMessage, "Error");
                }

                return Requests.Response(this, new ApiStatus(200), isMessage, "Success");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpPatch("UpdateCustomer")]
        [Authorize]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerDto model)
        {
            try
            {
                var (isAdded, isMessage) = await _customerAppService.Update(model);
                if (!isAdded)
                {
                    return Requests.Response(this, new ApiStatus(406), isMessage, "Error");
                }

                return Requests.Response(this, new ApiStatus(200), isMessage, "Success");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }
    }
}
