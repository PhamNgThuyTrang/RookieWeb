using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Data.SeedData
{
    public static class BannerDataInitializer
    {
        public static void SeedBannerData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>().HasData(
                new Banner
                {
                    BannerId = 1,
                    Name = "Women's Shoes, Clothing & Accessories",
                    ImagePath = "5ecc6547-f3c2-4b38-8528-c2e4dc5c0751.jpeg"
                },
                new Banner
                {
                    BannerId = 2,
                    Name = "Everlasting Love Pack: Available from 18 February",
                    ImagePath = "f6a57e16-2956-435e-843a-4ebd1ce0fb1f.jpeg"
                }
            );
        }

    }
}
