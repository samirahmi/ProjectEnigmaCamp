using Project7_wmbRESTApi.Application.DefaultServices.CustomerService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.Helpers
{
    public class PagedResult<T>
    {
        public PagedResult(IEnumerable<T> data, long total)
        {
            Data = data;
            Total = total;
        }

        public PagedResult()
        {

        }

        public IEnumerable<T> Data { get; set; }
        public long Total { get; set; }

    }
}
