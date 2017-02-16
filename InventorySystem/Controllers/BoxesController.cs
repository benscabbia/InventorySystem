using InventorySystem.Models;
using InventorySystem.Models.ViewModels;
using InventorySystem.Services;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    [Authorize]
    public class BoxesController : Controller
    {
        //return View(/*_db.Boxes.ToList()*/);
        private InventorySystemDb _db = new InventorySystemDb();
        private IBoxService service;

        public BoxesController()
        {
            this.service = new BoxService();
        }
        // GET: Boxes
        public ActionResult Index()
        {
            return View(service.GetBoxes());
        }

        // GET: Boxes/Details/5
        public ActionResult Details(int id)
        {
            return View(service.DetailsBox(id));

        }

        // GET: Boxes/Create
        public ActionResult Create()
        {
            return View(service.CreateBox());
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
                service.CreateBox(viewModel);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Boxes/Edit/5
        public ActionResult Edit(int id)
        {
            return View(service.EditBox(id));
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
                service.EditBox(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Boxes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(service.GetBox(id));
        }

        // POST: Boxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.RemoveBox(id);
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
