using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Product;
using System.Threading.Tasks;
public interface IProductService
{
    Task<PagedResponseDto<ProductDto>> GetProductAsync(ProductCriteriaDto productCriteriaDto);

    Task<PagedResponseDto<ProductDto>> GetProductsAsyncByProductModelId(int productModelId);

    Task<PagedResponseDto<ProductDto>> GetProductAsyncByCategory(int subCategoryId, ProductCriteriaDto productCriteriaDto);

    Task<ProductDto> GetProductAsyncById(int id);
}
