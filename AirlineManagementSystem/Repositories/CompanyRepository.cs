using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineManagementSystem.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace AirlineManagementSystem.Repositories
{
    public class CompanyRepository : DBGetId, ICompany
    {
        private dbAirlineEntities dbAirline;

        public CompanyRepository(dbAirlineEntities dbAirline)
        {
            this.dbAirline = dbAirline;
        }

        public IEnumerable<Companies> GetCompany()
        {
            return dbAirline.Companies.Where(a => a.IsDeleted == false).ToList();
        }

        public override Companies GetCompaniesById(int companyId)
        {
            return dbAirline.Companies.Find(companyId);
        }

        //public Companies GetCompaniesById(int companyId)
        //{
        //    return dbAirline.Companies.Find(companyId);
        //}

        public void InsertCompany(Companies comp)
        { 
            dbAirline.Companies.Add(comp);
        }

        public void DeleteCompany(int companyId)
        {
            Companies company = dbAirline.Companies.Find(companyId);
            company.IsDeleted = true;
            //dbAirline.Companies.Remove(company);
        }

        public void UpdateCompany(Companies comp)
        {
            dbAirline.Entry(comp).State = EntityState.Modified;
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