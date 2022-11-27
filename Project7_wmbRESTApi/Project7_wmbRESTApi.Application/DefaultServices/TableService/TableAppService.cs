using AutoMapper;
using Project7_wmbRESTApi.Application.DefaultServices.MenuService.Dto;
using Project7_wmbRESTApi.Application.DefaultServices.TableService.Dto;
using Project7_wmbRESTApi.Application.Helpers;
using Project7_wmbRESTApi.Database.DataBases;
using Project7_wmbRESTApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.DefaultServices.TableService
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

        public async Task<PagedResult<TableListDto>> GetAllTable(PageInfo pageInfo)
        {
            var pageResult = new PagedResult<TableListDto>
            {
                Data = (from table in _warungContext.Tables
                        join bill in _warungContext.Bills
                            on table.TableId equals bill.TableId
                        select new TableListDto
                        {
                            TableName = table.TableName,
                            BillId = bill.BillId,
                        })
                       .Skip(pageInfo.Skip)
                       .Take(pageInfo.PageSize),
                Total = _warungContext.Tables.Count()
            };

            return await Task.Run(() => pageResult);
        }

        public async Task<(bool, string)> Update(UpdateTableDto model)
        {
            try
            {
                var table = _mapper.Map<Table>(model);

                await _warungContext.Database.BeginTransactionAsync();
                _warungContext.Tables.Update(table);
                await _warungContext.SaveChangesAsync();

                await _warungContext.Database.CommitTransactionAsync();
                return await Task.Run(() => (true, "Success"));
            }
            catch (DbException dbex)
            {
                await _warungContext.Database.RollbackTransactionAsync();
                return await Task.Run(() => (false, dbex.Message));
            }
        }
    }
}
