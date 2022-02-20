using System;

namespace RookieShop.Shared.ViewModels
{
    public class BannerVm
    {
        public int BannerId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateUpload { get; set; }
    }
}
