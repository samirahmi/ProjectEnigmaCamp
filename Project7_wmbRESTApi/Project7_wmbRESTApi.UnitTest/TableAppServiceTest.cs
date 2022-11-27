using Moq;
using Project7_wmbRESTApi.Application.DefaultServices.MenuService.Dto;
using Project7_wmbRESTApi.Application.DefaultServices.TableService;
using Project7_wmbRESTApi.Application.DefaultServices.TableService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.UnitTest
{
    public class TableAppServiceTest
    {
        [Fact]
        public void GetAllTable()
        {
            //Arrange
            var tableAppService = new Mock<ITableAppService>();
            PageInfo pageInfo = new PageInfo()
            {
                Page = 1,
                PageSize = 5
            };

            //Act
            Task<PagedResult<TableListDto>> pagedResult = null;
            var result = tableAppService.Setup(x => x.GetAllTable(pageInfo)).Returns(pagedResult);

            //Assert
            Assert.NotNull(result);
        }


        [Fact]
        public void UpdateTable()
        {
            //Arrange
            var tableAppService = new Mock<ITableAppService>();
            UpdateTableDto updateTableDto = new UpdateTableDto()
            {
                TableId = 1,
                TableName = "T01",
                BillId = 1,
            };

            //Act
            var result = tableAppService.Setup(x => x.Update(updateTableDto));

            //Assert
            Assert.NotNull(result);
        }
    }
}
