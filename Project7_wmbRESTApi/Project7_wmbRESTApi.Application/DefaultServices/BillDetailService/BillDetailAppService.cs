using AutoMapper;
using Project7_wmbRESTApi.Application.DefaultServices.BillDetailService.Dto;
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

namespace Project7_wmbRESTApi.Application.DefaultServices.BillDetailService
{
    public class BillDetailAppService : IBillDetailAppService
    {
        private readonly WarungContext _warungContext;
        private IMapper _mapper;

        public BillDetailAppService(WarungContext warungContext, IMapper mapper)
        {
            _warungContext = warungContext;
            _mapper = mapper;
        }
        public async Task<(bool, string)> CreateBillDetail(CreateBillDetailDto model)
        {
            try
            {
                var billd = _mapper.Map<BillDetail>(model);

                await _warungContext.Database.BeginTransactionAsync();
                _warungContext.BillDetails.Add(billd);
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

        public async Task<PagedResult<BillDetailListDto>> SearchBill(int Id, PageInfo pageInfo)
        {
            var billds = from billd in _warungContext.BillDetails
                         select billd;
            if (Id != 0)
            {
                billds = billds.Where(s => s.BillId == Id);
            }

            var total = new BillDetailListDto();
            var pagedResult = new PagedResult<BillDetailListDto>
            {
                Data = (from billd in billds
                        join menuprice in _warungContext.MenuPrices
                           on billd.MenuPriceId equals menuprice.MenuPriceId
                        join bill in _warungContext.Bills
                           on billd.BillId equals bill.BillId
                        join menu in _warungContext.Menus
                           on menuprice.MenuId equals menu.MenuId
                        join customer in _warungContext.Customers
                           on bill.CustomerId equals customer.CustomerId
                        select new BillDetailListDto
                        {
                            BillId = bill.BillId,
                            BillDate = bill.TransactionDate,
                            CustomerName = customer.CustomerName,
                            MenuName = menu.MenuName,
                            Price = menuprice.Price,
                            Qty = billd.Qty,
                            Subtotal = total.Subtotal,
                            IsPayment = bill.IsPayment
                        })
                        .Skip(pageInfo.Skip)
                        .Take(pageInfo.PageSize)
                        .OrderBy(w => w.BillId),
                Total = _warungContext.BillDetails.Count()

            };

            return await Task.Run(() => pagedResult);
        }

        public async Task<(bool, string)> UpdateBillDetail(UpdateBillDetailDto model)
        {
            try
            {
                var billd = _mapper.Map<BillDetail>(model);

                await _warungContext.Database.BeginTransactionAsync();
                _warungContext.BillDetails.Update(billd);
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
