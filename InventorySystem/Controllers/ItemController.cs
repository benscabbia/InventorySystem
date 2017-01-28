using InventorySystem.Models;
using InventorySystem.Models.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

            var viewModel = new ItemCreateViewModel
            {
                Categories = _db.Categories.ToList(),
                Boxes = _db.Boxes.ToList()

            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(ItemCreateViewModel viewModel)
        {
            Item item;
            try
            {
                var ebayItem = EbayAPI.GetEbayItem(viewModel.ItemNumber);


                if (!ebayItem.HasError)
                {

                    item = new Item
                    {
                        ItemNumber = ebayItem.Item.ItemID,
                        Name = ebayItem.Item.Title,
                        BoxId = viewModel.BoxId,
                        Size = viewModel.Size,
                        CategoryId = viewModel.CategoryId,
                        EbayUrl = ebayItem.Item.ListingDetails.ViewItemURL,
                        Description = ebayItem.Item.Description,
                        Price = Convert.ToDecimal(ebayItem.Item.ListingDetails.ConvertedStartPrice.Value) //item.startprice.value

                    };
                }
                else
                {
                    throw new NullReferenceException("EbayItem has an error.ItemNumber=[" + ebayItem.Item.ItemID + "], if empty, item could not be found");
                }

                //condition describe ebayItem.Item.ConditionDescription

                //startime, endtime to be, ebayItem.Item.ListingDetail
                // location mums vs camb
                // number of views
                //item.TimeLeft; Time left before the listing ends. The duration is represented in the ISO 8601 duration format (PnYnMnDTnHnMnS). See Data Types in the Trading API Guide for information about this format. For ended listings, the time left is PT0S (zero seconds).

                //picture details url i.e. item.PictureDetails.GalleryURL
                // or PictureDetails.PictureURL.InnerList [array of image URL's]

                //ListingType i.e. FixedPriceItem -> maybe dynamic and get relevant values?

                //item.hitcount;

                //item.listingDetails. end time? , startTime

                //item.listingtype

                //item.relisted / item.relistlink / item.listeparentID

                //item.sellingstatus.listing status, item.quantity sold

                //shipping cost item.shippingdetails.shippingserviceoptions
                //if shippingserveroptions.count > 0, shippingserveroptions.list[0].shippingservicecost.value

                //watch count
            }
            catch (ArgumentException E)
            {
                ModelState.AddModelError("", E.ToString());
                var viewModelItem = new ItemCreateViewModel
                {
                    Categories = _db.Categories.ToList(),
                    Boxes = _db.Boxes.ToList()

                };
                return View(viewModelItem);
            }
            catch (NullReferenceException E)
            {
                ModelState.AddModelError("", E.ToString());
                var viewModelItem = new ItemCreateViewModel
                {
                    Categories = _db.Categories.ToList(),
                    Boxes = _db.Boxes.ToList()

                };
                return View(viewModelItem);
            }
            catch (Exception E)
            {
                ModelState.AddModelError("", E.ToString());
                var viewModelItem = new ItemCreateViewModel
                {
                    Categories = _db.Categories.ToList(),
                    Boxes = _db.Boxes.ToList()

                };
                return View(viewModelItem);
            }

            if (ModelState.IsValid)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                return RedirectToAction("Details", new { id = item.Id });
            }

            var viewItemModel = new ItemCreateViewModel
            {
                Categories = _db.Categories.ToList(),
                Boxes = _db.Boxes.ToList()

            };
            return View(viewItemModel);
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