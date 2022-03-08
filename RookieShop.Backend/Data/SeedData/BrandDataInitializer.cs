using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Models;
using RookieShop.Shared.Enum;

namespace RookieShop.Backend.Data.SeedData
{
    public static class BrandDataInitializer
    {
        public static void SeedBrandData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    BrandId = 1,
                    Name = "Nike",
                    Type = (int)BrandTypeEnum.Luxury
                },
                new Brand
                {
                    BrandId = 2,
                    Name = "Adidas",
                    Type = (int)BrandTypeEnum.Luxury
                },
                new Brand
                {
                    BrandId = 3,
                    Name = "Puma",
                    Type = (int)BrandTypeEnum.Normal
                },
                new Brand
                {
                    BrandId = 4,
                    Name = "Bitis",
                    Type = (int)BrandTypeEnum.All
                }
            );
        }
    }
}