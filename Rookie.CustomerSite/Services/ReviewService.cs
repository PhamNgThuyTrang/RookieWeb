using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


public class ReviewService : IReviewService
{
    private readonly IHttpClientFactory _clientFactory;

    public ReviewService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<PagedResponseDto<ReviewDto>> GetReviewsAsync(ReviewCriteriaDto reviewCriteriaDto)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var getEndpoint = string.IsNullOrEmpty(reviewCriteriaDto.Search) ?
                                    EndpointConstants.GET_REVIEWS :
                                    $"{EndpointConstants.GET_REVIEWS}?Search={reviewCriteriaDto.Search}";

        var response = await client.GetAsync(getEndpoint);
        response.EnsureSuccessStatusCode();
        var pagedReviews = await response.Content.ReadAsAsync<PagedResponseDto<ReviewDto>>();
        return pagedReviews;
    }

    public async Task<PagedResponseDto<ReviewDto>> GetReviewsAsyncByProductId(int productId, ReviewCriteriaDto reviewCriteriaDto)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var response = await client.GetAsync($"{EndpointConstants.GET_REVIEWS_BY_PRODUCTID}\\{productId}");
        response.EnsureSuccessStatusCode();
        var pagedReviews = await response.Content.ReadAsAsync<PagedResponseDto<ReviewDto>>();
        return pagedReviews;
    }

    public async Task<ReviewDto> GetReviewAsyncById(int id)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var response = await client.GetAsync($"{EndpointConstants.GET_REVIEW_BY_ID}\\{id}");
        response.EnsureSuccessStatusCode();
        var review = await response.Content.ReadAsAsync<ReviewDto>();
        return review;
    }
}
