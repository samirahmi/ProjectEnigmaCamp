using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project7_wmbRESTApi.Application.DefaultServices.BillDetailService;
using Project7_wmbRESTApi.Application.DefaultServices.BillDetailService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using Project7_wmbRESTApi.Application.Model;

namespace Project7_wmbRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
        private readonly IBillDetailAppService _billDetailAppService;
        public BillDetailController(IBillDetailAppService billDetailAppService)
        {
            _billDetailAppService = billDetailAppService;
        }

        [HttpGet("SearchBillDetail")]
        [Authorize]
        public async Task<IActionResult> SearchProduct(int id, [FromQuery] PageInfo pageInfo)
        {
            try
            {
                var data = await _billDetailAppService.SearchBill(id , pageInfo);
                if (data.Data.Count() < 1)
                {
                    return Requests.Response(this, new ApiStatus(404), null, "Not Found");
                }

                return Requests.Response(this, new ApiStatus(200), data, "");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpPost("SaveBillDetail")]
        [Authorize]
        public async Task<IActionResult> SaveBillDetail([FromBody] CreateBillDetailDto model)
        {
            try
            {
                var (isAdded, isMessage) = await _billDetailAppService.CreateBillDetail(model);
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

        [HttpPatch("UpdateBillDetail")]
        [Authorize]
        public async Task<IActionResult> UpdateBillDetail([FromBody] UpdateBillDetailDto model)
        {
            try
            {
                var (isAdded, isMessage) = await _billDetailAppService.UpdateBillDetail(model);
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
