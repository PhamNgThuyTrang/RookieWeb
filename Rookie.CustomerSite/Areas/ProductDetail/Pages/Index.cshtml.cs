using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Product;
using Rookie.CustomerSite.ViewModel.ProductImage;
using Rookie.CustomerSite.ViewModel.ProductSize;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto.ProductImage;
using RookieShop.Shared.Dto.ProductSize;
using RookieShop.Shared.Enum;

namespace Rookie.CustomerSite.Pages.ProductDetail
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IProductSizeService _productSizeService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public IndexModel(
            IProductService productService,
            IProductImageService productImageService,
            IProductSizeService productSizeService,
            ICategoryService categoryService,
            ISubCategoryService subCategoryService,
            IConfiguration config,
            IMapper mapper)
        {
            _productService = productService;
            _productImageService = productImageService;
            _productSizeService = productSizeService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _config = config;
            _mapper = mapper;
        }
        public ProductVm Product { get; set; }
        public PagedResponseVM<ProductVm> Color { get; set; }
        public PagedResponseVM<ProductImageVm> ProductImage { get; set; }
        public PagedResponseVM<ProductSizeVm> ProductSizes { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            #region ProductDetail
            var productDto = await _productService.GetProductAsyncById(id);
            if (productDto == null)
            {
                return NotFound();
            }
            Product = _mapper.Map<ProductVm>(productDto);
            #endregion

            //#region Breadcum
            //var productModelDto = await _productModelService.GetProductModelAsyncById(Product.ProductModelId);
            //if (productDto == null)
            //{
            //    return NotFound();
            //}

            //var category = await _subCategoryService.Ge(Product.ProductModelId);
            //if (productDto == null)
            //{
            //    return NotFound();
            //}
            //Product = _mapper.Map<ProductVm>(productDto);
            //#endregion


            #region ProductColor
            var productColorDto = await _productService.GetProductsAsyncByProductModelId(Product.ProductModelId);
            if (productColorDto == null)
            {
                return NotFound();
            }
            Color = _mapper.Map<PagedResponseVM<ProductVm>>(productColorDto);
            #endregion

            #region Image
            var productImageCriteriaDto = new ProductImageCriteriaDto()
            {
                ProductId = id,
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedImages = await _productImageService.GetProductImageAsync(productImageCriteriaDto);
            ProductImage = _mapper.Map<PagedResponseVM<ProductImageVm>>(pagedImages);
            #endregion

            #region Size
            var productSizeCriteriaDto = new ProductSizeCriteriaDto()
            {
                ProductId = id,
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedSizes = await _productSizeService.GetProductSizesAsync(productSizeCriteriaDto);
            ProductSizes = _mapper.Map<PagedResponseVM<ProductSizeVm>>(pagedSizes);
            #endregion

            return Page();
        }
    }
}
