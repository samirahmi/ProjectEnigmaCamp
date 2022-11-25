using AutoMapper;
using Project6_EFWMB.Application.BillDetailServices.Dto;
using Project6_EFWMB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.BillDetailServices
{
    internal class BillDetailAppService : IBillDetailAppService
    {
        private readonly WarungContext _warungContext;
        private IMapper _mapper;

        public BillDetailAppService(WarungContext warungContext, IMapper mapper)
        {
            _warungContext = warungContext;
            _mapper = mapper;
        }

        public void Create(CreateBillDetailDto model)
        {
            var billDetail = _mapper.Map<BillDetails>(model);
            _warungContext.BillDetails.Add(billDetail);
            _warungContext.SaveChanges();
        }
    }
}
