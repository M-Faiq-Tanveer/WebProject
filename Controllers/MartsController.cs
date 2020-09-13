using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FaiqTanveer.Models;

namespace FaiqTanveer.Controllers
{
    public class MartsController : Controller
    {
        private MartDBContext db = new MartDBContext();

        // GET: Marts
        public ActionResult Index(string searchString)
        {
            var marts = from mart in db.Marts
                         select mart;

            if (!String.IsNullOrEmpty(searchString))
            {
                marts = marts.Where(s => s.ItemName.Contains(searchString));
            }

            return View(marts);
        }

        // GET: Marts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mart mart = db.Marts.Find(id);
            if (mart == null)
            {
                return HttpNotFound();
            }
            return View(mart);
        }

        // GET: Marts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ItemName,ExpiryDate,Amount,Price")] Mart mart)
        {
            if (ModelState.IsValid)
            {
                db.Marts.Add(mart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mart);
        }

        // GET: Marts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mart mart = db.Marts.Find(id);
            if (mart == null)
            {
                return HttpNotFound();
            }
            return View(mart);
        }

        // POST: Marts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ItemName,ExpiryDate,Amount,Price")] Mart mart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mart);
        }

        // GET: Marts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mart mart = db.Marts.Find(id);
            if (mart == null)
            {
                return HttpNotFound();
            }
            return View(mart);
        }

        // POST: Marts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mart mart = db.Marts.Find(id);
            db.Marts.Remove(mart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
