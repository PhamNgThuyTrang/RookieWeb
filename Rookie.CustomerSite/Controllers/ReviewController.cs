using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Dto.Review;
using RookieShop.Shared.Request.Review;
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

        public async Task<IActionResult> ProductReview([Bind("Stars, Content, ProductId")] ReviewCreateRequest review)
        {
            if (ModelState.IsValid)
            {
                await _reviewService.PostReview(review);
                return Redirect($"../ProductDetail?id={review.ProductId}");
            }
            else
                return Redirect($"../ProductDetail?id={review.ProductId}");
        }

    }
}
