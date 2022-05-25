using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Models
{
    public class Locations_lkupController : Controller
    {
        private ChecklistsEntities db = new ChecklistsEntities();

        // GET: Locations_lkup
        public ActionResult Index()
        {
            return View(db.Locations_lkup.ToList());
        }

        // GET: Locations_lkup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locations_lkup locations_lkup = db.Locations_lkup.Find(id);
            if (locations_lkup == null)
            {
                return HttpNotFound();
            }
            return View(locations_lkup);
        }

        // GET: Locations_lkup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locations_lkup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FullName,PermissionCode,LocCode,Mall,State")] Locations_lkup locations_lkup)
        {
            if (ModelState.IsValid)
            {
                db.Locations_lkup.Add(locations_lkup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locations_lkup);
        }

        // GET: Locations_lkup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locations_lkup locations_lkup = db.Locations_lkup.Find(id);
            if (locations_lkup == null)
            {
                return HttpNotFound();
            }
            return View(locations_lkup);
        }

        // POST: Locations_lkup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullName,PermissionCode,LocCode,Mall,State")] Locations_lkup locations_lkup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locations_lkup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locations_lkup);
        }

        // GET: Locations_lkup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locations_lkup locations_lkup = db.Locations_lkup.Find(id);
            if (locations_lkup == null)
            {
                return HttpNotFound();
            }
            return View(locations_lkup);
        }

        // POST: Locations_lkup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locations_lkup locations_lkup = db.Locations_lkup.Find(id);
            db.Locations_lkup.Remove(locations_lkup);
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
