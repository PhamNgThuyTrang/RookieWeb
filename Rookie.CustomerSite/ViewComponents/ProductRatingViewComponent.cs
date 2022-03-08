using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Review;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto.Review;
using RookieShop.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewComponents
{
    public class ProductRatingViewComponent : ViewComponent
    {
        private readonly IReviewService _reviewService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public ProductRatingViewComponent(
            IReviewService reviewService,
            IConfiguration config,
            IMapper mapper
            )
        {
            _reviewService = reviewService;
            _config = config;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var reviewCriteriaDto = new ReviewCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedReviews = await _reviewService.GetReviewsAsyncByProductId(productId, reviewCriteriaDto);
            var reviews = _mapper.Map<PagedResponseVM<ReviewVm>>(pagedReviews);
            return View(reviews);
        }
    }
}
