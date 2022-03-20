using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Dto.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<IActionResult> ProductReview([Bind("Stars, Content, ProductId")] ReviewDto review)
        {
            await _reviewService.PostReview(review);
            return Redirect($"../ProductDetail?id={review.ProductId}");

        }

    }
}
