using AutoMapper;
using Project7_wmbRESTApi.Application.DefaultServices.BillService.Dto;
using Project7_wmbRESTApi.Application.DefaultServices.MenuService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using Project7_wmbRESTApi.Database.DataBases;
using Project7_wmbRESTApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.BillService
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
        public async Task<(bool, string)> CreateBill(CreateBillDto model)
        {
            try
            {
                var bill = _mapper.Map<Bill>(model);

                await _warungContext.Database.BeginTransactionAsync();
                _warungContext.Bills.Add(bill);
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

        public async Task<PagedResult<BillListDto>> GetAllBill(PageInfo pageinfo)
        {
            var pageResult = new PagedResult<BillListDto>
            {
                Data = (from bill in _warungContext.Bills
                        join customer in _warungContext.Customers
                            on bill.CustomerId equals customer.CustomerId
                        join table in _warungContext.Tables
                            on bill.TableId equals table.TableId
                        join transtype in _warungContext.TransTypes
                            on bill.TransTypeId equals transtype.TransTypeId
                        select new BillListDto
                        {
                            BillId = bill.BillId,
                            TransactionDate = bill.TransactionDate,
                            CustomerName = customer.CustomerName,
                            TableName = table.TableName,
                            TransTypeId = bill.TransTypeId,
                            IsPayment = bill.IsPayment,
                        })
                        .Skip(pageinfo.Skip)
                        .Take(pageinfo.PageSize)
                        .OrderBy(w => w.TransactionDate),
                Total = _warungContext.Bills.Count()
            };

            return await Task.Run(() => pageResult);
        }
    }
}
