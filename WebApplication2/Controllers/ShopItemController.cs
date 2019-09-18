using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ShopItemController : Controller
    {
        static List<ShopItem> ItemList;
        public ShopItemController()
        {
            if (ItemList == null)
            {
                ItemList = new List<ShopItem>();
                ItemList.Add(new ShopItem
                {
                    ID = 1,
                    Price = 6,
                    Name = "Hoodies"
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
            }
        }
        // GET: ShopItem
        public ActionResult Index()
        {
            return View(ItemList);
        }

        // GET: ShopItem/Details/5
        public ActionResult Details(int id)
        {
            return View(ItemList.FirstOrDefault(item=>item.ID==id));
        }

        // GET: ShopItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ItemList.Add(new ShopItem
                {
                    ID = ItemList.Max(Item=>Item.ID)+1,
                    Name=collection["Name"],
                    Price = int.Parse(collection["Price"])
                }) ;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ItemList.FirstOrDefault(item => item.ID == id));
        }

        // POST: ShopItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ShopItem item = ItemList.FirstOrDefault(x =>x.ID == id);
                item.Name = collection["Name"];
                item.Price = int.Parse(collection["Price"]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ItemList.FirstOrDefault(x => x.ID == id));
        }

        // POST: ShopItem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ShopItem item = ItemList.FirstOrDefault(x => x.ID == id);
                ItemList.Remove(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}