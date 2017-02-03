using InventorySystem.Models;
using InventorySystem.Models.ViewModels;
using InventorySystem.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class ItemController : Controller
    {
        InventorySystemDb _db = new InventorySystemDb();
        IItemService service;
        public ItemController()
        {
            this.service = new ItemService();
        }
        public ActionResult Index(string searchTerm = null)
        {

            var model = service.GetItemsSearch(searchTerm);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ViewItemsSimple", model);
            }

            return View(model);
        }

        // http://localhost:63038/Item/AutoComplete/?term=yo
        public ActionResult Autocomplete(string term)
        {
            var model = service.GetItemsSearch(term).Select(i => new
            {
                label = i.Name
            });

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View(service.GetItem(id));
        }

        // GET: Item/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(service.CreateItem());
        }
        [HttpPost]
        public ActionResult Create(ItemCreateViewModel viewModel)
        {
            Item item;
            if (ModelState.IsValid)
            {
                try
                {
                    item = service.CreateItem(viewModel);
                    return RedirectToAction("Details", new { id = item.Id });
                }
                catch (ArgumentException E)
                {
                    return View(HandleCreateItemError(E.ToString()));
                }
                catch (NullReferenceException E)
                {
                    return View(HandleCreateItemError(E.ToString()));
                }
                catch (Exception E)
                {
                    return View(HandleCreateItemError(E.ToString()));
                }

            }
            return View(HandleCreateItemError(null));
        }


        // GET: Item/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(service.EditItem(id));
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(ItemEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                service.EditItem(model);
            }

            return RedirectToAction("Details", new { id = model.Id });
        }


        // GET: /Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View(service.DeleteItem(id));
        }
        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.DeleteItemConfirmed(id);
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
        private ItemCreateViewModel HandleCreateItemError(string exception)
        {
            if (exception != null)
            {
                ModelState.AddModelError("", exception);
            }
            var viewItemModel = new ItemCreateViewModel
            {
                Categories = _db.Categories.ToList(),
                Boxes = _db.Boxes.ToList()

            };
            return viewItemModel;
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