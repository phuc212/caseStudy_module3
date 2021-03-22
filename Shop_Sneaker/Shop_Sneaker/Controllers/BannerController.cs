using Microsoft.AspNetCore.Mvc;
using Shop_Sneaker.Repository;
using Shop_Sneaker.ViewModel.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Controllers
{
    public class BannerController :Controller
    {
        private readonly IBanner bannerRepositori;

        public BannerController(IBanner bannerRepositori)
        {
            this.bannerRepositori = bannerRepositori;
        }
        public IActionResult Index()
        {
            var Categories = bannerRepositori.Gets();
            return View(Categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBanner model)
        {
            if (ModelState.IsValid)
            {
                if (bannerRepositori.CreateBanner(model) > 0)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên Danh Mục Đả Tồn Tại");
                    return View(model);
                }

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var banner = bannerRepositori.Get(id);
            var editBanner = new Edit()
            {
                BannerPhoto = banner.BannerPhoto,
                BannerName = banner.BannerName,
                BannerId = banner.BannerId,

            };
            return View(editBanner);

        }
        [HttpPost]
        public IActionResult Edit(Edit model)
        {
            if (ModelState.IsValid)
            {
                if (bannerRepositori.UpdateBanner(model) > 0)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
                else ModelState.AddModelError("", "Tên này đã tồn tại, vui lòng chọn tên khác");
            }
            return View();
        }
    }

}
