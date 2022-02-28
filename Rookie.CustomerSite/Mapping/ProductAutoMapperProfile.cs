using AutoMapper;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Product;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Mapping
{
    public class ProductAutoMapperProfile : Profile
    {
        public ProductAutoMapperProfile()
        {
            CreateMap<ProductDto, ProductVm>().ReverseMap();
            CreateMap<BaseQueryCriteriaDto, BaseQueryCriteriaVM>().ReverseMap();
            CreateMap<PagedResponseDto<ProductDto>, PagedResponseVM<ProductVm>>().ReverseMap();
        }
    }
}
