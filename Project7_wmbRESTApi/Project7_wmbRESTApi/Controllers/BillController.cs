using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project7_wmbRESTApi.Application.DefaultServices.BillService;
using Project7_wmbRESTApi.Application.DefaultServices.BillService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using Project7_wmbRESTApi.Application.Model;

namespace Project7_wmbRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillAppService _billAppService;

        public BillController(IBillAppService billAppService)
        {
            _billAppService = billAppService;
        }

        [HttpGet("GetAllListBill")]
        [Produces("application/json")]
        [Authorize]
        public async Task<IActionResult> GetAllBill([FromQuery] PageInfo pageInfo)
        {
            try
            {
                var productList = await _billAppService.GetAllBill(pageInfo);
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

        [HttpPost("SaveBill(TransTypeDIorTA)")]
        [Authorize]
        public async Task<IActionResult> SaveBill([FromBody] CreateBillDto model)
        {
            try
            {
                var (isAdded, isMessage) = await _billAppService.CreateBill(model);
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
