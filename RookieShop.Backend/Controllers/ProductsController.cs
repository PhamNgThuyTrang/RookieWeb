using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.BackEnd.Extension;
using RookieShop.BackEnd.Services;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Product;
using RookieShop.Shared.Request;
using RookieShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [Authorize("Bearer")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public ProductsController(
            ApplicationDbContext context,
            IFileStorageService fileStorageService,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<PagedResponseDto<ProductDto>>> GetProducts(
            [FromQuery] ProductCriteriaDto productCriteriaDto,
            CancellationToken cancellationToken)
        {
            var products = _context
                                .Products
                                .Where(x => !x.IsDeleted)
                                .AsQueryable();
            products = ProductFilter(products, productCriteriaDto);


            var pagedProducts = await products
                                .AsNoTracking()
                                .PaginateAsync(productCriteriaDto, cancellationToken);

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(pagedProducts.Items);
            return new PagedResponseDto<ProductDto>
            {
                CurrentPage = pagedProducts.CurrentPage,
                TotalPages = pagedProducts.TotalPages,
                TotalItems = pagedProducts.TotalItems,
                Search = productCriteriaDto.Search,
                SortColumn = productCriteriaDto.SortColumn,
                SortOrder = productCriteriaDto.SortOrder,
                Limit = productCriteriaDto.Limit,
                Items = productDtos
            };
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<ProductVm>> GetProduct(int id)
        {
            var product = await _context
                                .Products
                                .Where(x => !x.IsDeleted && x.ProductId == id)
                                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            var productVm = new ProductVm
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Color = product.Color,
                ListedPrice = product.ListedPrice,
                SellingPrice = product.SellingPrice,
                DateUpload = product.DateUpload,
                ProductModelId = product.ProductModelId
            };

            if (product.ImagePath != null)
            {
                productVm.ImagePath = _fileStorageService.GetFileUrl(product.ImagePath);
            }

            if (product.ProductImages != null)
            {
                productVm.ProductImages = _mapper.Map<List<ProductImageVm>>(product.ProductImages);
            }

            if (product.ProductSizes != null)
            {
                productVm.ProductSizes = _mapper.Map<List<ProductSizeVm>>(product.ProductSizes);
            }

            return productVm;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> PutProduct([FromRoute] int id, [FromForm] ProductEditRequest productCreateRequest)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(productCreateRequest.Name))
            {
                product.Name = productCreateRequest.Name;
            }

            if (!string.IsNullOrEmpty(productCreateRequest.Color))
            {
                product.Color = productCreateRequest.Color;
            }

            if (productCreateRequest.ListedPrice != 0)
            {
                product.ListedPrice = productCreateRequest.ListedPrice;
            }

            if (productCreateRequest.SellingPrice != 0)
            {
                product.SellingPrice = productCreateRequest.SellingPrice;
            }

            if (productCreateRequest.ProductModelId != 0)
            {
                product.ProductModelId = productCreateRequest.ProductModelId;
            }

            if (productCreateRequest.ImageFile != null)
            {
                product.ImagePath = await _fileStorageService.SaveFileAsync(productCreateRequest.ImageFile);
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPost]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<BannerVm>> PostProduct([FromForm] ProductCreateRequest productCreateRequest)
        {
            var product = new Product
            {
                Name = productCreateRequest.Name,
                Color = productCreateRequest.Color,
                ListedPrice = productCreateRequest.ListedPrice,
                SellingPrice = productCreateRequest.SellingPrice,
                ProductModelId = productCreateRequest.ProductModelId
            };

            if (productCreateRequest.ImageFile != null)
            {
                product.ImagePath = await _fileStorageService.SaveFileAsync(productCreateRequest.ImageFile);
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, 
                                    new ProductVm 
                                    { 
                                        ProductId = product.ProductId, 
                                        Name = product.Name,
                                        Color = product.Color,
                                        ListedPrice = product.ListedPrice,
                                        SellingPrice = product.SellingPrice,
                                        ProductModelId = product.ProductModelId,
                                        ImagePath = product.ImagePath,
                                        DateUpload = product.DateUpload
                                    });
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            //_context.Products.Remove(product);
            product.IsDeleted = true;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        #region Private Method
        private IQueryable<Product> ProductFilter(
            IQueryable<Product> products,
            ProductCriteriaDto productCriteriaDto)
        {
            if (productCriteriaDto.GetProductImage == true)
            {
                products = products.Include(x => x.ProductImages);
            }

            if (productCriteriaDto.GetProductSize == true)
            {
                products = products.Include(x => x.ProductSizes);
            }

            if (!String.IsNullOrEmpty(productCriteriaDto.Search))
            {
                products = products.Where(b =>
                    b.Name.Contains(productCriteriaDto.Search));
            }

            return products;
        }
        #endregion
    }
}
