using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project7_wmbRESTApi.Application.DefaultServices.MenuService;
using Project7_wmbRESTApi.Application.DefaultServices.MenuService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using Project7_wmbRESTApi.Application.Model;

namespace Project7_wmbRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuAppService _menuAppService;
        public MenuController(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }

        [HttpGet("GetAllMenu")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProduct([FromQuery] PageInfo pageInfo)
        { 
            try
            {
                var productList = await _menuAppService.GetAllMenu(pageInfo);
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

        [HttpGet("SearchMenu")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchProduct(string searchString, [FromQuery] PageInfo pageInfo)
        {
            try
            {
                var data = await _menuAppService.SearchMenu(searchString, pageInfo);
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
    }
}
