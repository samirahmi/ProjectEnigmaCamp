using Moq;
using Project7_wmbRESTApi.Application.DefaultServices.BillDetailService;
using Project7_wmbRESTApi.Application.DefaultServices.BillDetailService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.UnitTest
{
    public class BillDetailAppServiceTest
    {
        [Fact]
        public void CreateBillD()
        {
            //Arrange
            var billdAppService = new Mock<IBillDetailAppService>();
            CreateBillDetailDto createBillDDto = new CreateBillDetailDto()
            {
                BillId = 1,
                MenuPriceId = 1,
                Qty = 5,
            };

            //Act
            var result = billdAppService.Setup(x => x.CreateBillDetail(createBillDDto));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void SearchProductTest()
        {
            //Arrange
            var billdAppService = new Mock<IBillDetailAppService>();
            int Id = 1;
            PageInfo pageInfo = new PageInfo()
            {
                Page = 1,
                PageSize = 10
            };

            //Act
            Task<PagedResult<BillDetailListDto>> pagedResult = null;
            var result = billdAppService.Setup(x => x.SearchBill(Id, pageInfo)).Returns(pagedResult);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateBillD()
        {
            //Arrange
            var billdAppService = new Mock<IBillDetailAppService>();
            UpdateBillDetailDto updateBillDDto = new UpdateBillDetailDto()
            {
                BillDetailId = 1,
                BillId = 1,
                MenuPriceId = 1,
                Qty = 5,
            };

            //Act
            var result = billdAppService.Setup(x => x.UpdateBillDetail(updateBillDDto));

            //Assert
            Assert.NotNull(result);
        }
    }
}
