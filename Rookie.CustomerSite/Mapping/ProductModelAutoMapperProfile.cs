using AutoMapper;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.ProductModel;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Mapping
{
    public class ProductModelAutoMapperProfile : Profile
    {
        public ProductModelAutoMapperProfile()
        {
            CreateMap<ProductModelDto, ProductModelVm>().ReverseMap();
        }
    }
}
