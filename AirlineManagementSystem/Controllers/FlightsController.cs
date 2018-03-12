using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirlineManagementSystem.Models;

namespace AirlineManagementSystem.Controllers
{
    public class FlightsController : Controller
    {
        private dbAirlineEntities db = new dbAirlineEntities();

        // GET: Flights
        public ActionResult Index()
        {
            var flights = db.Flights.Include(f => f.Companies).Include(f => f.Statuses);
            return View(flights.ToList());
        }

        // GET: Flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights flights = db.Flights.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            return View(flights);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name");
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Name");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightId,Flight_Nr,From,To,ArriveTime,ExpectedTime,StatusId,CompanyId,FlightType,CreatedOnDate,LastModifiedOnDate,CreatedByUserId,LastModifiedByUserId,IsDeleted")] Flights flights)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flights);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", flights.CompanyId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Name", flights.StatusId);
            return View(flights);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights flights = db.Flights.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", flights.CompanyId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Name", flights.StatusId);
            return View(flights);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightId,Flight_Nr,From,To,ArriveTime,ExpectedTime,StatusId,CompanyId,FlightType,CreatedOnDate,LastModifiedOnDate,CreatedByUserId,LastModifiedByUserId,IsDeleted")] Flights flights)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flights).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", flights.CompanyId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Name", flights.StatusId);
            return View(flights);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights flights = db.Flights.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            return View(flights);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flights flights = db.Flights.Find(id);
            db.Flights.Remove(flights);
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
