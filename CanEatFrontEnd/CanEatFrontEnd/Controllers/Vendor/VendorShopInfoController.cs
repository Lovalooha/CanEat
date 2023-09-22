﻿using CanEatFrontEnd.Models;
using CanEatFrontEnd.Models.PageModel.VendorShopInfo;
using Microsoft.AspNetCore.Mvc;

namespace CanEatFrontEnd.Controllers.Vendor
{
    public class VendorShopInfoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            VendorShopInfoModel model = new VendorShopInfoModel();

            //Models.Vendor v1 = new Models.Vendor();
            //Models.Food f1 = new Models.Food();
            //Models.Food f2 = new Models.Food();
            //Models.Food f3 = new Models.Food();

            //model.currVendor = v1;
            //model.foodList.Add(f1);
            //model.foodList.Add(f2);
            //model.foodList.Add(f3);

            //v1.Name = "Rocky Rooster";

            //f1.Id = "abc-123";
            //f1.Name = "Paket A";
            //f1.Price = 25000;
            //f1.Description = "1 pcs Ayam Goreng Dada / Paha Atas + 1 pcs Ayam Goreng Sayap + Nasi Putih";

            //f2.Id = "def-456";
            //f2.Name = "Paket B";
            //f2.Price = 27000;
            //f2.Description = "1 pcs Ayam Goreng Dada / Paha Atas + 2 pcs Ayam Goreng Sayap + Nasi Putih";

            //f3.Id = "ghi-789";
            //f3.Name = "Paket C";
            //f3.Price = 30000;
            //f3.Description = "2 pcs Ayam Goreng Dada / Paha Atas + 2 pcs Ayam Goreng Sayap + Nasi Putih + Minum";

            string id = HttpContext.Session.GetString("Id");
            model.currVendor = await Models.Vendor.getVendor(id);
            model.foodList = await Models.Food.getFoodVendor(id);

            return View("Views/Vendor/ShopInfo/Index.cshtml", model);
        }

        public async Task<IActionResult> deleteDish(string id)
        {
            await Models.Food.deleteFood(id);
            return RedirectToAction("Index", "VendorShopInfo");
        }
    }
}
