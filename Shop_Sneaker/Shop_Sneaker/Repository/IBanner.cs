using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    interface IBanner
    {
        public List<BannerViewModel> Gets();
        public BannerRepository Get(int id);
        public bool Delete(int id);
        public int CreateBanner(string categoryCreate);
        public int UpdateBanner(string categoryEdit);
    }
}
