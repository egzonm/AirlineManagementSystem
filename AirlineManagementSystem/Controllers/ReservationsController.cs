using System;
using System.Data;
using System.Web.Mvc;
using AirlineManagementSystem.Models;
using AirlineManagementSystem.Repositories;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace AirlineManagementSystem.Controllers
{
    public class ReservationsController : Controller
    {
        private dbAirlineEntities db = new dbAirlineEntities();

        private IReservation reservationRepository;
         

        public ReservationsController()
        {
            this.reservationRepository = new ReservationRepository(new dbAirlineEntities());
        } 

        // GET: Reservations
        [Authorize]
        public ActionResult Index()
        { 
            return View(reservationRepository.GetReservation());
        }

        // GET: Reservations/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Reservation reservation = db.Reservation.Find(id);
        //    if (reservation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(reservation);
        //}

        // GET: Reservations/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId,From,Destination,DateFrom,DateTo,FlighType,NoChildren,CreatedOnDate,LastModifiedOnDate,CreatedByUserId,LastModifiedByUserId,IsDeleted")] Reservation reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    reservation.CreatedByUserId = User.Identity.GetUserId();
                    reservation.CreatedOnDate = DateTime.Now;
                    reservation.LastModifiedByUserId = User.Identity.GetUserId();
                    reservation.LastModifiedOnDate = DateTime.Now;
                    reservation.IsDeleted = false;
                    reservationRepository.InsertReservation(reservation);
                    reservationRepository.Save();

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            }
            

            return View(reservation);
        }
         

        // GET: Reservations/Edit/5
        public ActionResult Edit(int id)
        {
            Reservation res = reservationRepository.GetReservationById(id);
            if (res == null)
            {
                return HttpNotFound();
            }
            return View(res);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationId,From,Destination,DateFrom,DateTo,FlighType,NoChildren,CreatedOnDate,LastModifiedOnDate,CreatedByUserId,LastModifiedByUserId,IsDeleted")] Reservation reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    reservation.LastModifiedByUserId = User.Identity.GetUserId();
                    reservation.LastModifiedOnDate = DateTime.Now;
                    reservationRepository.UpdateReservation(reservation);
                    reservationRepository.Save();

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            }
            
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int id)
        {
            Reservation res = reservationRepository.GetReservationById(id);
            if (res == null)
            {
                return HttpNotFound();
            }
            return View(res);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Reservation reservation = reservationRepository.GetReservationById(id);
                reservationRepository.DeleteReservation(id);
                reservationRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            } 

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            reservationRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
