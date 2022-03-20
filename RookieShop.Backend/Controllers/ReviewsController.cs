using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.BackEnd.Extension;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Review;
using RookieShop.Shared.Request;
using RookieShop.Shared.Request.Review;
using RookieShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    [Authorize("Bearer")]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReviewsController(
            ApplicationDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<PagedResponseDto<ReviewDto>>> GetReviews(
            [FromQuery] ReviewCriteriaDto reviewCriteriaDto,
            CancellationToken cancellationToken)
        {
            var reviews = _context
                                .Reviews
                                .Where(x => !x.IsDeleted)
                                .AsQueryable();

            var pagedReviews = await reviews
                                .AsNoTracking()
                                .PaginateAsync(reviewCriteriaDto, cancellationToken);

            var reviewDtos = _mapper.Map<IEnumerable<ReviewDto>>(pagedReviews.Items);

            return new PagedResponseDto<ReviewDto>
            {
                CurrentPage = pagedReviews.CurrentPage,
                TotalPages = pagedReviews.TotalPages,
                TotalItems = pagedReviews.TotalItems,
                Search = reviewCriteriaDto.Search,
                SortColumn = reviewCriteriaDto.SortColumn,
                SortOrder = reviewCriteriaDto.SortOrder,
                Limit = reviewCriteriaDto.Limit,
                Items = reviewDtos
            };
        }
        
        [HttpGet("{productId}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<PagedResponseDto<ReviewDto>>> GetReviewsByProductId(
            int productId,
            [FromQuery] ReviewCriteriaDto reviewCriteriaDto,
            CancellationToken cancellationToken)
        {
            var reviews = _context
                                .Reviews
                                .Where(x => x.ProductId == productId)
                                .Where(x => !x.IsDeleted)
                                .Include(x => x.User)
                                .AsQueryable();

            var pagedReviews = await reviews
                                .AsNoTracking()
                                .PaginateAsync(reviewCriteriaDto, cancellationToken);

            var reviewDtos = _mapper.Map<IEnumerable<ReviewDto>>(pagedReviews.Items);

            return new PagedResponseDto<ReviewDto>
            {
                CurrentPage = pagedReviews.CurrentPage,
                TotalPages = pagedReviews.TotalPages,
                TotalItems = pagedReviews.TotalItems,
                Search = reviewCriteriaDto.Search,
                SortColumn = reviewCriteriaDto.SortColumn,
                SortOrder = reviewCriteriaDto.SortOrder,
                Limit = reviewCriteriaDto.Limit,
                Items = reviewDtos
            };
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<ReviewVm>> GetReview(int id)
        {
            var review = await _context
                                .Reviews
                                .Where(x => !x.IsDeleted && x.ReviewId == id)
                                .FirstOrDefaultAsync();

            if (review == null)
            {
                return NotFound();
            }

            var reviewVm = new ReviewVm
            {
                ReviewId = review.ReviewId,
                Stars = review.Stars,
                Content = review.Content,
                DateUpload = review.DateUpload,
                ProductId = review.ProductId,
                UserId = review.UserId
            };

            return reviewVm;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> PutReview([FromRoute] int id, [FromForm] ReviewEditRequest reviewEditRequest)
        {
            if (ModelState.IsValid)
                try
                {
                    var review = await _context.Reviews.FindAsync(id);

                    if (review == null)
                    {
                        return NotFound();
                    }

                    if (reviewEditRequest.Stars != null)
                    {
                        review.Stars = reviewEditRequest.Stars;
                    }
                    if (!string.IsNullOrEmpty(reviewEditRequest.Content))
                    {
                        review.Content = reviewEditRequest.Content;
                    }
                    if (reviewEditRequest.ProductId != null)
                    {
                        review.ProductId = reviewEditRequest.ProductId;
                    }
                    if (!string.IsNullOrEmpty(reviewEditRequest.UserId))
                    {
                        review.UserId = reviewEditRequest.UserId;
                    }

                    _context.Reviews.Update(review);
                    await _context.SaveChangesAsync();

                    return Ok(review);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            else
            {
                return null;
            }
        }

        [HttpPost]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        [AllowAnonymous]
        public async Task<ActionResult<ReviewVm>> PostReview([FromForm] ReviewCreateRequest reviewCreateRequest)
            {
                if (ModelState.IsValid)
                    try
                    {
                        var review = new Review
                        {
                            Stars = Int32.Parse(reviewCreateRequest.Stars),
                            Content = reviewCreateRequest.Content,
                            ProductId = Int32.Parse(reviewCreateRequest.ProductId),
                            UserId = reviewCreateRequest.UserId,
                        };

                        _context.Reviews.Add(review);
                        await _context.SaveChangesAsync();

                        return CreatedAtAction("GetReview", new { id = review.ReviewId },
                            new ReviewVm {
                                ReviewId = review.ReviewId,
                                Stars = review.Stars,
                                Content = review.Content,
                                DateUpload = review.DateUpload,
                                ProductId = review.ProductId,
                                UserId = review.UserId
                            });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                else
                {
                    return null;
                }
            }

            [HttpDelete("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            //_context.Reviews.Remove(review);
            review.IsDeleted = true;
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();

            return Ok(true);
        }
    }
}
