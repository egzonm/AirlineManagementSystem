using System;
using System.Collections.Generic;
using System.Linq;
using AirlineManagementSystem.Models;
using System.Data.Entity;

namespace AirlineManagementSystem.Repositories
{
    public  class CountryRepository : ICountry
    {
        private dbAirlineEntities dbAirline;

        public CountryRepository(dbAirlineEntities dbAirline)
        {
            this.dbAirline = dbAirline;
        }

        public void DeleteCountry(int countryId)
        {
            Country country = dbAirline.Country.Find(countryId);
            country.IsDeleted = true;
            //dbAirline.Companies.Remove(company);
        }

        public IEnumerable<Country> GetCountry()
        {
            return dbAirline.Country.Where(a => a.IsDeleted == false).ToList();
        }

        public Country GetCountryById(int countryId)
        {
            return dbAirline.Country.Find(countryId);
        }

        public void InsertCountry(Country country)
        {
            dbAirline.Country.Add(country);
        }

        public void Save()
        {
            dbAirline.SaveChanges();
        }

        public void UpdateCountry(Country country)
        {
            dbAirline.Entry(country).State = EntityState.Modified;
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