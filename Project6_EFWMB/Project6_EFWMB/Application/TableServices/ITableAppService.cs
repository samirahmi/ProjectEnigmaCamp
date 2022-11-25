using Project6_EFWMB.Application.TableServices.Dto;
using Project6_EFWMB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.TableServices
{
    public interface ITableAppService
    {
        void Update(UpdateTableDto model);
        UpdateTableDto GetTableByCode(string tablecode);
        List<TableListDto> GetAllTable();
    }
}
