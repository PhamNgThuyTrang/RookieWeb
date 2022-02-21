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
                    Name = "Test Brand 1",
                    Type = (int)BrandTypeEnum.Normal
                },
                new Brand
                {
                    BrandId = 2,
                    Name = "Test Brand 2",
                    Type = (int)BrandTypeEnum.Normal
                },
                new Brand
                {
                    BrandId = 3,
                    Name = "Test Brand 3",
                    Type = (int)BrandTypeEnum.Normal
                },
                new Brand
                {
                    BrandId = 4,
                    Name = "Test Brand 4",
                    Type = (int)BrandTypeEnum.Luxury
                },
                new Brand
                {
                    BrandId = 5,
                    Name = "Test Brand 5",
                    Type = (int)BrandTypeEnum.Luxury
                },
                new Brand
                {
                    BrandId = 6,
                    Name = "Test Brand 6",
                    Type = (int)BrandTypeEnum.Luxury
                }
            );
        }
    }
}