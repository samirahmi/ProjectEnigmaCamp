using AutoMapper;
using Project7_wmbRESTApi.Application.DefaultServices.BillDetailService.Dto;
using Project7_wmbRESTApi.Application.DefaultServices.BillService.Dto;
using Project7_wmbRESTApi.Application.DefaultServices.CustomerService.Dto;
using Project7_wmbRESTApi.Application.DefaultServices.MenuService.Dto;
using Project7_wmbRESTApi.Application.DefaultServices.TableService.Dto;
using Project7_wmbRESTApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7_wmbRESTApi.Application.ConfigProfiles
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Customer, CreateCustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();

            CreateMap<Customer, UpdateCustomerDto>();
            CreateMap<UpdateCustomerDto, Customer>();

            CreateMap<MenuPrice, MenuListDto>();
            CreateMap<MenuListDto, MenuPrice>();

            CreateMap<Menu, MenuListDto>();
            CreateMap<MenuListDto, Menu>();

            CreateMap<Bill, CreateBillDto>();
            CreateMap<CreateBillDto, Bill>();

            CreateMap<Bill, BillListDto>();
            CreateMap<BillListDto, Bill>();

            CreateMap<BillDetail, CreateBillDetailDto>();
            CreateMap<CreateBillDetailDto, BillDetail>();

            CreateMap<BillDetail, BillDetailListDto>();
            CreateMap<BillDetailListDto, BillDetail>();

            CreateMap<BillDetail, UpdateBillDetailDto>();
            CreateMap<UpdateBillDetailDto, BillDetail>();

            CreateMap<Table, TableListDto>();
            CreateMap<TableListDto, Table>();

            CreateMap<Table, UpdateTableDto>();
            CreateMap<UpdateTableDto, Table>();
        }
    }
}
