using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineManagementSystem.Models;
using System.Data.Entity;

namespace AirlineManagementSystem.Repositories
{
    public class CityRepository : ICity
    {
        private dbAirlineEntities dbAirline;

        public CityRepository(dbAirlineEntities dbAirline)
        {
            this.dbAirline = dbAirline;
        }

        public IEnumerable<Cities> GetCity()
        {
            return dbAirline.Cities.Where(a => a.IsDeleted == false).ToList();
        }

        public Cities GetCityById(int cityId)
        {
            return dbAirline.Cities.Find(cityId);
        }

        public void InsertCity(Cities city)
        {
            dbAirline.Cities.Add(city);
        }

        public void DeleteCity(int cityId)
        {
            Cities city = dbAirline.Cities.Find(cityId);
            city.IsDeleted = true;
        }

        public void UpdateCity(Cities city)
        {
            dbAirline.Entry(city).State = EntityState.Modified;
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