using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Review;
using RookieShop.Shared.Request.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IReviewService
{
    Task<PagedResponseDto<ReviewDto>> GetReviewsAsync(ReviewCriteriaDto reviewCriteriaDto);
    Task<PagedResponseDto<ReviewDto>> GetReviewsAsyncByProductId(int productId, ReviewCriteriaDto reviewCriteriaDto);
    Task<ReviewDto> GetReviewAsyncById(int id);
    Task<bool> PostReview(ReviewCreateRequest reviewCreateRequest);

}
