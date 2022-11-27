using Project7_wmbRESTApi.Application.DefaultServices.BillDetailService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.BillDetailService
{
    public interface IBillDetailAppService
    {
        Task<(bool, string)> CreateBillDetail(CreateBillDetailDto model);
        Task<(bool, string)> UpdateBillDetail(UpdateBillDetailDto model);
        Task<PagedResult<BillDetailListDto>> SearchBill(int Id, PageInfo pageInfo);
    }
}
