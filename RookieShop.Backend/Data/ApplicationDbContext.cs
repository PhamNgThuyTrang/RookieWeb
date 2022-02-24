using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data.SeedData;
using RookieShop.Backend.Models;

namespace RookieShop.Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> productImages { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedBrandData();
            modelBuilder.SeedBannerData();
            modelBuilder.SeedCategoryData();
            modelBuilder.SeedSubCategoryData();
            base.OnModelCreating(modelBuilder);
        }
    }
}
