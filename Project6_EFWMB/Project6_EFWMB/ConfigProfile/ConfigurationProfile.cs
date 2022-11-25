using AutoMapper;
using Project6_EFWMB.Application.BillDetailServices.Dto;
using Project6_EFWMB.Application.BillServices.Dto;
using Project6_EFWMB.Application.CustomerServices.Dto;
using Project6_EFWMB.Application.MenuServices.Dto;
using Project6_EFWMB.Application.TableServices.Dto;
using Project6_EFWMB.Application.TransactionServices.Dto;
using Project6_EFWMB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB.ConfigProfile
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<MenuPrices, MenuListDto>();
            CreateMap<MenuListDto, MenuPrices>();

            CreateMap<Tables, TableListDto>();
            CreateMap<TableListDto, Tables>();

            CreateMap<Tables, UpdateTableDto>();
            CreateMap<UpdateTableDto, Tables>();

            CreateMap<Bills, CreateBillDto>();
            CreateMap<CreateBillDto, Bills>();

            CreateMap<Bills, BillListDto>();
            CreateMap<BillListDto, Bills>();

            CreateMap<Customers, CreateCustomerDto>();
            CreateMap<CreateCustomerDto, Customers>();

            CreateMap<BillDetails, CreateBillDetailDto>();
            CreateMap<CreateBillDetailDto, BillDetails>();

        }

    }
}
