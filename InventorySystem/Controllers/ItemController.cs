using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class ItemController : Controller
    {
        InventorySystemDb _db = new InventorySystemDb();
        public ActionResult Index()
        {

            var model = (from i in _db.Items
                         orderby i.Name
                         select i);

            return View(model);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            var model = (from i in _db.Items
                        where i.Id == id
                        select i).Single();

            return View(model);
        }

        // GET: Item/Create
        [HttpGet]        
        public ActionResult Create()
        {            
            ViewBag.BoxesId = new SelectList(_db.Boxes, "Id", "Label");            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Item item)
        {
            
            try
            {
                var ebayItem = EbayAPI.GetEbayItem(item.ItemNumber);
                
                item.ItemNumber = ebayItem.Item.ItemID;
                item.Name = ebayItem.Item.Title;
                item.EbayUrl = ebayItem.Item.ListingDetails.ViewItemURL;
                item.Price = Convert.ToDecimal(ebayItem.Item.ListingDetails.ConvertedStartPrice);
                item.Description = ebayItem.Item.Description;
                
                
                //condition describe ebayItem.Item.ConditionDescription

                //startime, endtime to be, ebayItem.Item.ListingDetail
                // location mums vs camb
                // number of views
                //item.TimeLeft; Time left before the listing ends. The duration is represented in the ISO 8601 duration format (PnYnMnDTnHnMnS). See Data Types in the Trading API Guide for information about this format. For ended listings, the time left is PT0S (zero seconds).
                
                //picture details url i.e. item.PictureDetails.GalleryURL
                // or PictureDetails.PictureURL.InnerList [array of image URL's]

                //ListingType i.e. FixedPriceItem -> maybe dynamic and get relevant values?
            }
            catch (ArgumentException)
            {
                ViewBag.BoxesId = new SelectList(_db.Boxes, "Id", "Label");
                return View(item);
            }

            if (ModelState.IsValid)
            {
                _db.Items.Add(item);                
                _db.SaveChanges();
                return RedirectToAction("Details", new { id = item.Id });
            }

            ViewBag.BoxesId = new SelectList(_db.Boxes, "Id", "Label");
            return View(item);
        }

        // GET: Item/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Items.Find(id);
            return View(model);
        }

        // POST: Item/Edit/5
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


        // GET: /Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = _db.Items.Find(id);
            _db.Items.Remove(item);       
            // If issues, use below
            // _db.Entry(item).State = EntityState.Delete;     
            _db.SaveChanges();
            return RedirectToAction("Index");
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