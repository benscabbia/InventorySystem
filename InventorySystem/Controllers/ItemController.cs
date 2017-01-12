using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class ItemController : Controller
    {
        InventorySystemDb _db = new InventorySystemDb();

        // GET: Item
        public ActionResult Index()
        {
            var model2 = _db.Items.ToList();

            var model =
                from i in items
                orderby i.Name
                select i;

            return View(model2);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
        }

        static List<Item> items = new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "Yoda",
                Description = "",
                Price = 8,
                Category = Categories.Disney,
                EbayUrl = "www.google.com",
                BoxId = 1
            },
            new Item
            {
                Id = 2,
                Name = "Bart Simpson",
                Description = "Small canvas",
                Price = 3,
                Category = Categories.TV,
                EbayUrl = "www.sims.com",
                BoxId = 4
            }

        };

    }
}
