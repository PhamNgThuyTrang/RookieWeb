using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Dto.Banner
{
    public class BannerDto
    {
        public int BannerId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateUpload { get; set; }

    }
}
