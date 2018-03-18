using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineManagementSystem.Models;
using System.Data.Entity;

namespace AirlineManagementSystem.Repositories
{
    public class ReservationRepository : IReservation
    {
        private dbAirlineEntities dbAirline;

        public ReservationRepository(dbAirlineEntities dbAirline)
        {
            this.dbAirline = dbAirline;
        }

        public IEnumerable<Reservation> GetReservation()
        {
            return dbAirline.Reservation.Where(a => a.IsDeleted == false).ToList();
        }

        public Reservation GetReservationById(int reservationId)
        {
            return dbAirline.Reservation.Find(reservationId);
        }

        public void InsertReservation(Reservation res)
        {
            dbAirline.Reservation.Add(res);
        }

        public void DeleteReservation(int reservationId)
        {
            Reservation res = dbAirline.Reservation.Find(reservationId);
            res.IsDeleted = true;
            //dbAirline.Companies.Remove(company);
        }

        public void UpdateReservation(Reservation res)
        {
            dbAirline.Entry(res).State = EntityState.Modified;
        }
        
        public void Save()
        {
            dbAirline.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbAirline.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }  
    }
}