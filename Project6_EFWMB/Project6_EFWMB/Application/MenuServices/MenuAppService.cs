using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project6_EFWMB.Application.MenuServices.Dto;
using Project6_EFWMB.Database;
using Project6_EFWMB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.MenuServices
{
    public class MenuAppService : IMenuAppService
    {
        private readonly WarungContext _warungContext;
        private IMapper _mapper;

        public MenuAppService(WarungContext warungContext, IMapper mapper)
        {
            _warungContext = warungContext;
            _mapper = mapper;
        }

        public MenuListDto GetMenuByCode(int id)
        {
            var menu = _warungContext.MenuPrices.AsNoTracking().FirstOrDefault(w => w.MenusId == id);
            var menuDto = _mapper.Map<MenuListDto>(menu);
            return menuDto;
        }

        public PagedResult<MenuListDto> GetAllMenus(PageInfo pageinfo)
        {
            var pagedResult = new PagedResult<MenuListDto>
            {
                Data = (from menu in _warungContext.Menus
                        join menuprice in _warungContext.MenuPrices
                             on menu.MenusId equals menuprice.MenusId
                        select new MenuListDto
                        {
                            MenuCode = menu.MenuCode,
                            MenuName = menu.MenuName,
                            Price = menuprice.Price,
                            MenuPricesId = menuprice.MenuPricesId
                        })
                       .Take(pageinfo.PageSize)
                       .OrderBy(w => w.MenuCode),
                Total = _warungContext.Menus.Count()
            };

            return pagedResult;
        }
    }
}
