using Project7_wmbRESTApi.Application.DefaultServices.MenuService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.MenuService
{
    public interface IMenuAppService
    {
        Task<PagedResult<MenuListDto>> GetAllMenu(PageInfo pageInfo);
        Task<PagedResult<MenuListDto>> SearchMenu(string searchString, PageInfo pageInfo);
    }
}
