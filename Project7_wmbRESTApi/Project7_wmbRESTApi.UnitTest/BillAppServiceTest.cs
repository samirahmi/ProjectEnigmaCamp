using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project7_wmbRESTApi.Application.DefaultServices.BillService.Dto;
using Project7_wmbRESTApi.Application.DefaultServices.BillService;
using Project7_wmbRESTApi.Application.Helpers;

namespace Project7_wmbRESTApi.UnitTest
{
    public class BillAppServiceTest
    {
        [Fact]
        public void CreateBill()
        {
            //Arrange
            var billAppService = new Mock<IBillAppService>();
            CreateBillDto createBillDto = new CreateBillDto()
            {
                CustomerId = 1,
                TransactionDate = DateTime.Now,
                TableId = 1,
                TransTypeId = "ta",
                IsPayment = "done"
            };

            //Act
            var result = billAppService.Setup(x => x.CreateBill(createBillDto));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllBill()
        {
            //Arrange
            var billAppService = new Mock<IBillAppService>();
            PageInfo pageInfo = new PageInfo()
            {
                Page = 1,
                PageSize = 5
            };

            //Act
            Task<PagedResult<BillListDto>> pagedResult = null;
            var result = billAppService.Setup(x => x.GetAllBill(pageInfo)).Returns(pagedResult);

            //Assert
            Assert.NotNull(result);
        }
    }
}
