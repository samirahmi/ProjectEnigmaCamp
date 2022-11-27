using AutoMapper;
using Project7_wmbRESTApi.Application.DefaultServices.CustomerService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using Project7_wmbRESTApi.Database.DataBases;
using Project7_wmbRESTApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.CustomerService
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

        public async Task<(bool, string)> Update(UpdateCustomerDto model)
        {
            try
            {
                var customer = _mapper.Map<Customer>(model);

                await _warungContext.Database.BeginTransactionAsync();
                _warungContext.Customers.Update(customer);
                await _warungContext.SaveChangesAsync();

                await _warungContext.Database.CommitTransactionAsync();
                return await Task.Run(() => (true, "Success"));
            }
            catch (DbException dbex)
            {
                await _warungContext.Database.RollbackTransactionAsync();
                return await Task.Run(() => (false, dbex.Message));
            }
        }

        public async Task<(bool, string)> Create(CreateCustomerDto model)
        {
            try
            {
                var customer = _mapper.Map<Customer>(model);

                await _warungContext.Database.BeginTransactionAsync();
                _warungContext.Customers.Add(customer);
                await _warungContext.SaveChangesAsync();

                await _warungContext.Database.CommitTransactionAsync(); 
                return (true, "Success");
            }
            catch (DbException dbex)
            {
                await _warungContext.Database.RollbackTransactionAsync();
                return await Task.Run(() => (false, dbex.Message));
            }
        }
    }
}
