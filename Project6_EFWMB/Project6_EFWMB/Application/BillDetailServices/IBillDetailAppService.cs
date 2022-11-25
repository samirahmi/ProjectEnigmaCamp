using Project6_EFWMB.Application.BillDetailServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.BillDetailServices
{
    public interface IBillDetailAppService
    {
        void Create(CreateBillDetailDto model);
    }
}
