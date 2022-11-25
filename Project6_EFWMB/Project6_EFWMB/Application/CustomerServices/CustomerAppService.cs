using AutoMapper;
using Project6_EFWMB.Application.CustomerServices.Dto;
using Project6_EFWMB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.CustomerServices
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly WarungContext _warungContext;
        private IMapper _mapper;

        public CustomerAppService(WarungContext warungContext, IMapper mapper)
        {
            _warungContext = warungContext;
            _mapper = mapper;
        }

        public void Create(CreateCustomerDto model)
        {
            var countId = _warungContext.Customers.Count();
            countId = countId + 1;
            var product = _mapper.Map<Customers>(model);
            product.CustomersId = countId;
            _warungContext.Customers.Add(product);
            _warungContext.SaveChanges();
        }
    }
}
