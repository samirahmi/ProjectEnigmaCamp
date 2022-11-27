
using Project7_wmbRESTApi.Application.DefaultServices.TableService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.TableService
{
    public interface ITableAppService
    {
        Task<PagedResult<TableListDto>> GetAllTable(PageInfo pageInfo);
        Task<(bool, string)> Update(UpdateTableDto model);
    }
}
