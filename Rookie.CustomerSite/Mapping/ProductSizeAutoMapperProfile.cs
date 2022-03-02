using AutoMapper;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.ProductSize;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.ProductSize;

namespace Rookie.CustomerSite.Mapping
{
    public class ProductSizeAutoMapperProfile : Profile
    {
        public ProductSizeAutoMapperProfile()
        {
            CreateMap<ProductSizeDto, ProductSizeVm>().ReverseMap();
            CreateMap<BaseQueryCriteriaDto, BaseQueryCriteriaVM>().ReverseMap();
            CreateMap<PagedResponseDto<ProductSizeDto>, PagedResponseVM<ProductSizeVm>>().ReverseMap();
        }
    }
}
