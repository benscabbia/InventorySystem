using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventorySystem.Models;

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
            return View(box);
        }

        // GET: Boxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Label,Capacity,Fullness,Value,Category")] Box box)
        {
            if (ModelState.IsValid)
            {
                _db.Boxes.Add(box);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(box);
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
            return View(box);
        }

        // POST: Boxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Label,Capacity,Fullness,Value,Category")] Box box)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(box).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(box);
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
