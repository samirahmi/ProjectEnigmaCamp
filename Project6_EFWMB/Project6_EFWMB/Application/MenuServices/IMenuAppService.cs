using Project6_EFWMB.Application.MenuServices.Dto;
using Project6_EFWMB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.MenuServices
{
    public interface IMenuAppService
    {
        PagedResult<MenuListDto> GetAllMenus(PageInfo pageinfo);
        public MenuListDto GetMenuByCode(int id);
    }
}
