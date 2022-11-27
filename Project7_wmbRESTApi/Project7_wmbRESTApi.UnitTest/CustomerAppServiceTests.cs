using Moq;
using Project7_wmbRESTApi.Application.DefaultServices.CustomerService;
using Project7_wmbRESTApi.Application.DefaultServices.CustomerService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.UnitTest
{
    public class CustomerAppServiceTests
    {
        [Fact]
        public void CreateCustomer()
        {
            //Arrange
            var customerAppService = new Mock<ICustomerAppService>();
            CreateCustomerDto createCustomerDto = new CreateCustomerDto()
            {
                CustomerName = "YUTA",
                MobilePhone = "0800889977",
                IsMember = true,
            };

            //Act
            var result = customerAppService.Setup(x => x.Create(createCustomerDto));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateCustomer()
        {
            //Arrange
            var customerAppService = new Mock<ICustomerAppService>();
            UpdateCustomerDto updateCustomerDto = new UpdateCustomerDto()
            {
                CustomerName = "YUTA",
                MobilePhone = "0800889977",
                IsMember = true,
            };

            //Act
            var result = customerAppService.Setup(x => x.Update(updateCustomerDto));

            //Assert
            Assert.NotNull(result);
        }
    }
}
