using InventorySystem.Models;
using InventorySystem.Models.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class BoxesController : Controller
    {
        private InventorySystemDb _db = new InventorySystemDb();

        // GET: Boxes
        public ActionResult Index()
        {
            return View(_db.Boxes.ToList());
        }

        // GET: Boxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Box box = _db.Boxes.Find(id);
            if (box == null)
            {
                return HttpNotFound();
            }

            var items = box.Items.ToList();
            return View(new BoxItemsViewModel(box, items));
        }

        // GET: Boxes/Create
        public ActionResult Create()
        {

            var viewModel = new BoxCreateViewModel
            {
                Categories = _db.Categories.ToList()
            };


            return View(viewModel);
        }

        // POST: Boxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoxCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var box = new Box
                {
                    Label = viewModel.Label,
                    Capacity = viewModel.Capacity,
                    CategoryId = viewModel.CategoryId
                };
                _db.Boxes.Add(box);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Boxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Box box = _db.Boxes.Find(id);

            if (box == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BoxEditViewModel
            {
                Id = box.Id,
                Label = box.Label,
                Capacity = box.Capacity,
                CategoryId = box.CategoryId,
                Categories = _db.Categories.ToList()
            };
            return View(viewModel);
        }

        // POST: Boxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BoxEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var box = _db.Boxes.Find(viewModel.Id);

                box.Label = viewModel.Label;
                box.CategoryId = viewModel.CategoryId;
                box.Capacity = viewModel.Capacity;

                _db.Entry(box).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Boxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Box box = _db.Boxes.Find(id);
            if (box == null)
            {
                return HttpNotFound();
            }
            return View(box);
        }

        // POST: Boxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Box box = _db.Boxes.Find(id);
            _db.Boxes.Remove(box);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
