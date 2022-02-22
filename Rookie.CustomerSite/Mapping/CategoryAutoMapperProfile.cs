using AutoMapper;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Category;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Category;

namespace Rookie.CustomerSite.Mapping
{
    public class CategoryAutoMapperProfile : Profile
    {
        public CategoryAutoMapperProfile()
        {
            CreateMap<CategoryDto, CategoryVm>().ReverseMap();
            CreateMap<BaseQueryCriteriaDto, BaseQueryCriteriaVM>().ReverseMap();
            CreateMap<PagedResponseDto<CategoryDto>, PagedResponseVM<CategoryVm>>().ReverseMap();
        }
    }
}
