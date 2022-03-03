using RookieShop.Shared.Dto.SubCategory;

namespace RookieShop.Shared.Dto.ProductModel
{
    public class ProductModelDto
    {
        public int ProductModelId { get; set; }
        public int BrandId { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategoryDto SubCategory { get; set; }
    }
}
