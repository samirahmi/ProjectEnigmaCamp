using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project7_wmbRESTApi.Application.DefaultServices.CustomerService.Dto;
using Project7_wmbRESTApi.Application.DefaultServices.TableService;
using Project7_wmbRESTApi.Application.DefaultServices.TableService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using Project7_wmbRESTApi.Application.Model;

namespace Project7_wmbRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableAppService _tableAppService;
        public TableController(ITableAppService tableAppService)
        {
            _tableAppService = tableAppService;
        }

        [HttpGet("GetUsedTable")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProduct([FromQuery] PageInfo pageInfo)
        {
            try
            {
                var productList = await _tableAppService.GetAllTable(pageInfo);
                if (productList.Data.Count() < 1)
                {
                    return Requests.Response(this, new ApiStatus(404), null, "Not Found");
                }

                return Requests.Response(this, new ApiStatus(200), productList, "");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpPost("UpdateTable")]
        [Authorize]
        public async Task<IActionResult> UpdateTable([FromBody] UpdateTableDto model)
        {
            try
            {
                var (isAdded, isMessage) = await _tableAppService.Update(model);
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
