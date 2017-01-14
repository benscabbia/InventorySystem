using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class HomeController : Controller
    {
        InventorySystemDb _db = new InventorySystemDb();
        public ActionResult Index()
        {

            var model = (from i in _db.Items
                         orderby i.Name
                         select i);

            return View(model);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var model = (from i in _db.Items
                        where i.Id == id
                        select i).Single();

            return View(model);
        }

        // GET: Home/Create
        [HttpGet]        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                return RedirectToAction("Details", new { id = item.Id });
            }
            return View(item);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _db.Items.Find(id);
            return View(model);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(item).State = EntityState.Modified;
                    _db.SaveChanges(); 
                }

                return RedirectToAction("Details", new { id = item.Id });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}