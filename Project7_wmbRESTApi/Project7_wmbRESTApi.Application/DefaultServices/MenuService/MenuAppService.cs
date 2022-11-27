using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project7_wmbRESTApi.Application.DefaultServices.MenuService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using Project7_wmbRESTApi.Database.DataBases;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.MenuService
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

        public async Task<PagedResult<MenuListDto>> GetAllMenu(PageInfo pageInfo)
        {
            var pageResult = new PagedResult<MenuListDto>
            {
                Data = (from menu in _warungContext.Menus
                        join menuprice in _warungContext.MenuPrices
                             on menu.MenuId equals menuprice.MenuId
                        select new MenuListDto
                        {
                            MenuCode = menu.MenuCode,
                            MenuName = menu.MenuName,
                            Price = menuprice.Price,
                        })
                        .Skip(pageInfo.Skip)
                        .Take(pageInfo.PageSize)
                        .OrderBy(w => w.MenuCode),
                Total = _warungContext.Menus.Count()
            };

            return await Task.Run(() => pageResult);
        }

        public async Task<PagedResult<MenuListDto>> SearchMenu(string searchString, PageInfo pageInfo)
        {
            var menus = from menu in _warungContext.Menus
                           select menu;
            if (!String.IsNullOrEmpty(searchString))
            {
                menus = menus.Where(s => s.MenuName.Contains(searchString)
                                    || s.MenuCode.Contains(searchString));
            }

            var pagedResult = new PagedResult<MenuListDto>
            {
                Data = (from menu in menus
                        join menuprice in _warungContext.MenuPrices
                           on menu.MenuId equals menuprice.MenuId
                        select new MenuListDto
                        {
                            MenuCode = menu.MenuCode,
                            MenuName = menu.MenuName,
                            Price = menuprice.Price,
                        })
                        .Skip(pageInfo.Skip)
                        .Take(pageInfo.PageSize)
                        .OrderBy(w => w.MenuCode),
                Total = _warungContext.Menus.Count()
            };

            return await Task.Run(() => pagedResult);
        }
    }
}
