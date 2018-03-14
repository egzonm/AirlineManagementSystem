using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirlineManagementSystem.Models;
using AirlineManagementSystem.Repositories;
using Microsoft.AspNet.Identity;

namespace AirlineManagementSystem.Controllers
{
    public class FlightsController : Controller
    {
        private dbAirlineEntities db = new dbAirlineEntities();

        private IFlight flightRepository;

        public FlightsController()
        {
            this.flightRepository =  new FlightRepository(new dbAirlineEntities());
        }

        // GET: Flights
        public ActionResult Index()
        { 
            return View(flightRepository.GetFlights());
        }

        //// GET: Flights/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Flights flights = db.Flights.Find(id);
        //    if (flights == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(flights);
        //}

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
            try
            {
                if (ModelState.IsValid)
                {
                    flights.CreatedByUserId = User.Identity.GetUserId();
                    flights.LastModifiedByUserId = User.Identity.GetUserId();
                    flights.CreatedOnDate = DateTime.Now;
                    flights.LastModifiedOnDate = DateTime.Now;
                    flights.IsDeleted = false;
                    flightRepository.InsertFlight(flights);
                    flightRepository.Save();

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            }
            
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", flights.CompanyId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Name", flights.StatusId);
            return View(flights);
        }

        // GET: Flights/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Flights flights = flightRepository.GetFlightById(id);
  
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
            try
            {
                if (ModelState.IsValid)
                {
                    flights.LastModifiedByUserId = User.Identity.GetUserId();
                    flights.LastModifiedOnDate = DateTime.Now;
                    flightRepository.UpdateFlight(flights);
                    flightRepository.Save();

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            { 
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            }
            
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", flights.CompanyId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Name", flights.StatusId);
            return View(flights);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int id)
        {
            Flights flights = flightRepository.GetFlightById(id);

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
            try
            {
                Flights flights = flightRepository.GetFlightById(id);
                flightRepository.DeleteFlight(id);
                flightRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            } 
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            flightRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
