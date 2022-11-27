using Moq;
using Project7_wmbRESTApi.Application.DefaultServices.MenuService;
using Project7_wmbRESTApi.Application.DefaultServices.MenuService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.UnitTest
{
    public class MenuAppServiceTests
    {
        [Fact]
        public void GetAllProductTest()
        {
            //Arrange
            var productAppService = new Mock<IMenuAppService>();
            PageInfo pageInfo = new PageInfo()
            {
                Page = 1,
                PageSize = 5
            };

            //Act
            Task<PagedResult<MenuListDto>> pagedResult = null;
            var result = productAppService.Setup(x => x.GetAllMenu(pageInfo)).Returns(pagedResult);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void SearchProductTest()
        {
            //Arrange
            var productAppService = new Mock<IMenuAppService>();
            string searchString = "F01";
            PageInfo pageInfo = new PageInfo()
            {
                Page = 1,
                PageSize = 10
            };

            //Act
            Task<PagedResult<MenuListDto>> pagedResult = null;
            var result = productAppService.Setup(x => x.SearchMenu(searchString, pageInfo)).Returns(pagedResult);

            //Assert
            Assert.NotNull(result);

        }
    }
}
