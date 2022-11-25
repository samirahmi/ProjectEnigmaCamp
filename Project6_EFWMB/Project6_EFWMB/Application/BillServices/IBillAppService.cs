using Project6_EFWMB.Application.BillServices.Dto;
using Project6_EFWMB.Application.TransactionServices.Dto;
using Project6_EFWMB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.TransactionServices
{
    public interface IBillAppService
    {
        int Create(CreateBillDto model);
        PagedResult<BillListDto> GetAllBills(PageInfo pageinfo);
        public CreateBillDto GetMenuByCode(int id);
    }
}
