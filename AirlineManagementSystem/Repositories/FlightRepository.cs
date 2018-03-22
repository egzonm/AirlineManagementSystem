using System;
using System.Collections.Generic;
using System.Linq;
using AirlineManagementSystem.Models;
using System.Data.Entity;

namespace AirlineManagementSystem.Repositories
{
    public class FlightRepository : IFlight
    {
        private dbAirlineEntities dbAirline;

        public FlightRepository(dbAirlineEntities dbAirline)
        {
            this.dbAirline = dbAirline;
        }

        public IEnumerable<Flights> GetFlights()
        {
            //var flights = dbAirline.Flights.Include(f => f.Companies).Include(f => f.Statuses);
            //return dbAirline.Flights.Where(a => a.IsDeleted == false).Include(f => f.Companies).Include(f => f.Statuses).ToList();
            return dbAirline.Flights.Where(a => a.IsDeleted == false).ToList();
        }

        public Flights GetFlightById(int flightId)
        {
            return dbAirline.Flights.Find(flightId);
        }

        public void InsertFlight(Flights flight)
        {
            dbAirline.Flights.Add(flight);
        }

        public void DeleteFlight(int flightId)
        {
            Flights flight = dbAirline.Flights.Find(flightId);
            flight.IsDeleted = true;
            //dbAirline.Companies.Remove(company);
        }

        public void UpdateFlight(Flights flight)
        {
            dbAirline.Entry(flight).State = EntityState.Modified;
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