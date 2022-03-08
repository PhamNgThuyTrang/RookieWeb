using AutoMapper;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Banner;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Banner;

namespace Rookie.CustomerSite.Mapping
{
    public class BannerAutoMapperProfile : Profile
    {
        public BannerAutoMapperProfile()
        {
            CreateMap<BannerDto, BannerVm>().ReverseMap();
            CreateMap<BaseQueryCriteriaDto, BaseQueryCriteriaVM>().ReverseMap();
            CreateMap<PagedResponseDto<BannerDto>, PagedResponseVM<BannerVm>>().ReverseMap();
        }
    }
}
