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

        public ActionResult GoToFitzMall(string keywordSearch)
        {

            return Redirect("https://responsive.fitzmall.com/Inventory/SearchResults?KeyWordSearch=" + keywordSearch + "&Sort=&inventoryGrid_length=10&UseCriteria=true");
        }


        // GET: UnCheckedCars
        public ActionResult Index(string ploc, string sortOrder)
        {
            var SORTED_UnCheckedCars = from sDD in db.UnCheckedCars.OrderBy(a => a.loc)
                                                   select sDD;

            if (ploc == null) {
                ploc = "";
            }
                if (ploc == "") {
            }
            else
            {
                SORTED_UnCheckedCars = from sDD in db.UnCheckedCars.Where(a => a.loc == ploc)
                                       select sDD;

            }

            ViewBag.LocationCode = ploc;


            SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderBy(a => a.MetaDataValue7);

            switch (sortOrder)
            {
                case "VIN":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderBy(a => a.MetaDataValue7);
                    break;

                case "VIN_Descending":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderByDescending(a => a.MetaDataValue7);
                    break;

                case "Make":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderBy(a => a.MetaDataValue4 + a.MetaDataValue5);
                    break;

                case "Make_Descending":
                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderByDescending(a => a.MetaDataValue4 + a.MetaDataValue5);
                    break;

                case "Model":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderBy(a => a.MetaDataValue5);
                    break;

                case "Model_Descending":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderByDescending(a => a.MetaDataValue5);
                    break;

                case "StockNum":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderBy(a => a.MetaDataValue6);
                    break;

                case "StockNum_Descending":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderByDescending(a => a.MetaDataValue6);
                    break;

                case "Year":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderBy(a => a.MetaDataValue3);
                    break;

                case "Year_Descending":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderByDescending(a => a.MetaDataValue3);
                    break;
              case "Location":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderBy(a => a.loc);
                    break;

                case "Location_Descending":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderByDescending(a => a.loc);
                    break;

                case "Days":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderBy(a => a.days);
                    break;

                case "Days_Descending":

                    SORTED_UnCheckedCars = SORTED_UnCheckedCars.OrderByDescending(a => a.days);
                    break;

                default:

                    break;

            }

            ViewBag.SortOrder = sortOrder;
            return View(SORTED_UnCheckedCars);


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
