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
    public class UnCheckedCarsController : Controller
    {
        private ChecklistsEntities db = new ChecklistsEntities();

        // GET: UnCheckedCars
        public ActionResult Index(string ploc)
        {

                if (ploc == null) {
                ploc = "";
            }
                if (ploc == "") { 
                    return View(db.UnCheckedCars.ToList());
                }

            ViewBag.LocationCode = ploc;

               return View(db.UnCheckedCars.Where(a => a.loc == ploc));
        }

        // GET: UnCheckedCars/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnCheckedCar unCheckedCar = db.UnCheckedCars.Find(id);
            if (unCheckedCar == null)
            {
                return HttpNotFound();
            }
            return View(unCheckedCar);
        }

        // GET: UnCheckedCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnCheckedCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MetaDataValue1,MetaDataValue2,MetaDataValue3,MetaDataValue4,MetaDataValue5,MetaDataValue6,MetaDataValue7,MetaDataValue8,Status,UserID,FullName,DateCreated,DateUpdated")] UnCheckedCar unCheckedCar)
        {
            if (ModelState.IsValid)
            {
                db.UnCheckedCars.Add(unCheckedCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unCheckedCar);
        }

        // GET: UnCheckedCars/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnCheckedCar unCheckedCar = db.UnCheckedCars.Find(id);
            if (unCheckedCar == null)
            {
                return HttpNotFound();
            }
            return View(unCheckedCar);
        }

        // POST: UnCheckedCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MetaDataValue1,MetaDataValue2,MetaDataValue3,MetaDataValue4,MetaDataValue5,MetaDataValue6,MetaDataValue7,MetaDataValue8,Status,UserID,FullName,DateCreated,DateUpdated")] UnCheckedCar unCheckedCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unCheckedCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unCheckedCar);
        }

        // GET: UnCheckedCars/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnCheckedCar unCheckedCar = db.UnCheckedCars.Find(id);
            if (unCheckedCar == null)
            {
                return HttpNotFound();
            }
            return View(unCheckedCar);
        }

        // POST: UnCheckedCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            UnCheckedCar unCheckedCar = db.UnCheckedCars.Find(id);
            db.UnCheckedCars.Remove(unCheckedCar);
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
