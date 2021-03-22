using Microsoft.AspNetCore.Hosting;
using Shop_Sneaker.AppDbContexts;
using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel.Banner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Repository
{
    public class BannerRepository : IBanner
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BannerRepository(AppDbContext context,
                                  IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public int CreateBanner(CreateBanner createBanner)
        {
            var count = 0;
            foreach (var item in context.banners)
            {
                if (item.BannerName == createBanner.BannerName)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                var banner = new Banner()
                {
                    BannerName = createBanner.BannerName,
                    Description = createBanner.Description,
                };
                var fileName = string.Empty;
                if (createBanner.BannerImage != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/Banner");
                    fileName = $"{Guid.NewGuid()}_{createBanner.BannerImage.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        createBanner.BannerImage.CopyTo(fs);
                    }
                }
                if (createBanner.BannerImage == null)
                {
                    fileName = "~/images/Banner/nonCat.jpg";
                }
                banner.BannerPhoto = fileName;
                context.banners.Add(banner);
                return context.SaveChanges();
            }
            return 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Banner Get(int id)
        {
            return context.banners.Find(id);
        }

        public List<Banner> Gets()
        {
            return context.banners.ToList();
        }

        public int UpdateBanner(string editBanner)
        {
            throw new NotImplementedException();
        }
    }
}
