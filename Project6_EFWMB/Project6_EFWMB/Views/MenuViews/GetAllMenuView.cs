using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Project6_EFWMB.Application.MenuServices;
using Project6_EFWMB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Views.MenuViews
{
    public class GetAllMenuView
    {
        private IMenuAppService _menuAppService;

        public GetAllMenuView(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }
        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("List Of Menu");
            Console.WriteLine("--------------------------------");

            Console.Write("Enter Page          : ");
            int page = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Page Size     : ");
            int pageSize = Convert.ToInt32(Console.ReadLine());

            var pageInfo = new PageInfo(page, pageSize);
            var menuList = _menuAppService.GetAllMenus(pageInfo);

            var totalPage = menuList.Total / pageSize;

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Display Page : {page}, with total page : {Math.Abs(totalPage)}\n");

            foreach (var m in menuList.Data)
            {
                Console.WriteLine($"{m.MenuCode} - {m.MenuName} - {m.Price}");
            }

            Console.ReadKey();
        }
    }
}
