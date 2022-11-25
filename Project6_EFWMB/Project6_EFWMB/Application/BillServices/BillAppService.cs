using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project6_EFWMB.Application.BillServices.Dto;
using Project6_EFWMB.Application.MenuServices.Dto;
using Project6_EFWMB.Application.TransactionServices.Dto;
using Project6_EFWMB.Database;
using Project6_EFWMB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.TransactionServices
{
    public class BillAppService : IBillAppService
    {
        private readonly WarungContext _warungContext;
        private IMapper _mapper;

        public BillAppService(WarungContext warungContext, IMapper mapper)
        {
            _warungContext = warungContext;
            _mapper = mapper;
        }

        public int Create(CreateBillDto model)
        {
            var bill = _mapper.Map<Bills>(model);

            _warungContext.Bills.Add(bill);
            _warungContext.SaveChanges();
            _warungContext.Entry(bill).GetDatabaseValues();
            int id = bill.BillsId;
            return id;
        }

        public CreateBillDto GetMenuByCode(int id)
        {
            var product = _warungContext.Tables.AsNoTracking().FirstOrDefault(w => w.TablesId == id);
            var productDto = _mapper.Map<CreateBillDto>(product);
            return productDto;
        }

        public PagedResult<BillListDto> GetAllBills(PageInfo pageinfo)
        {
            var pagedResult = new PagedResult<BillListDto>
            {
                Data = (from bill in _warungContext.Bills
                        join customer in _warungContext.Customers
                            on bill.CustomersId equals customer.CustomersId
                        join table in _warungContext.Tables
                            on bill.TablesId equals table.TablesId
                        join transtype in _warungContext.TransTypes
                            on bill.TransTypesId equals transtype.TransTypesId
                        select new BillListDto
                        {
                            BillsId = bill.BillsId,
                            TransactionDate = bill.TransactionDate,
                            CustomersId = bill.CustomersId,
                            CustomerName = customer.CustomerName,
                            TableName = table.TableName,
                            TransTypesId = bill.TransTypesId,

                        })
                        //.Skip(pageinfo.Skip)
                        .Take(pageinfo.PageSize)
                        .OrderBy(w => w.BillsId),
                Total = _warungContext.Bills.Count()
            };

            return pagedResult;
        }
    }
}
