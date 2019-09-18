using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<ShopItem> ItemList = new List<ShopItem>();
            ItemList.Add(new ShopItem
            {
                ID = 1,
                Price = 6,
                Name="Hoodies"
            });
            ItemList.Add(new ShopItem
            {
                ID = 3,
                Price = 4,
                Name = "T-Shirt"
            });
            ItemList.Add(new ShopItem
            {
                ID = 2,
                Price = 7,
                Name = "Pants"
            });
            ViewData["ItemList"] = ItemList;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
