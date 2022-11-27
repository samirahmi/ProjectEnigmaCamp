using Project7_wmbRESTApi.Application.DefaultServices.BillService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.BillService
{
    public interface IBillAppService
    {

        Task<(bool, string)> CreateBill(CreateBillDto model);
        Task<PagedResult<BillListDto>> GetAllBill(PageInfo pageinfo);
    }
}
