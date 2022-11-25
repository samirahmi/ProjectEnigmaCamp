using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project6_EFWMB.Application.TableServices.Dto;
using Project6_EFWMB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.Application.TableServices
{
    public class TableAppService : ITableAppService
    {
        private readonly WarungContext _warungContext;
        private IMapper _mapper;

        public TableAppService(WarungContext warungContext, IMapper mapper)
        {
            _warungContext = warungContext;
            _mapper = mapper;
        }
        public List<TableListDto> GetAllTable()
        {
            var tableList = _warungContext.Tables.ToList();
            var tableListDto = _mapper.Map<List<TableListDto>>(tableList);
            return tableListDto;
        }

        public UpdateTableDto GetTableByCode(string tablecode)
        {
            var table = _warungContext.Tables.AsNoTracking().FirstOrDefault(w => w.TableName == tablecode);
            var tableDto = _mapper.Map<UpdateTableDto>(table);
            return tableDto;
        }

        public void Update(UpdateTableDto model)
        {
            var table = _mapper.Map<Tables>(model);
            _warungContext.Tables.Update(table);
            _warungContext.SaveChanges();
        }
    }
}
