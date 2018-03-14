using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirlineManagementSystem.Models;
using Microsoft.AspNet.Identity;
using AirlineManagementSystem.Repositories;

namespace AirlineManagementSystem.Controllers
{
    public class CompanyController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        //private dbAirlineEntities db = new dbAirlineEntities();

        private ICompany companyRepository;

        public CompanyController()
        {
            this.companyRepository = new CompanyRepository(new dbAirlineEntities());
        }

        // GET: Company
        [Authorize]
        public ActionResult Index()
        {
            return View(companyRepository.GetCompany()); 
        }

        // GET: Company/Details/5
        //public ActionResult Details(int id)
        //{
        //    Companies comp = companyRepository.GetCompaniesById(id);

        //    if (comp == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comp);
        //}

        //GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Country,CreatedOnDate,LastModifiedOnDate,CreatedByUserId,LastModifiedByUserId,IsDeleted")] Companies model)
        { 
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedByUserId = User.Identity.GetUserId();
                    model.LastModifiedByUserId = User.Identity.GetUserId();
                    model.CreatedOnDate = DateTime.Now;
                    model.LastModifiedOnDate = DateTime.Now;
                    model.IsDeleted = false;
                    companyRepository.InsertCompany(model);
                    companyRepository.Save();

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            { 
                ModelState.AddModelError(string.Empty,"Unable to save changes. Try again.");
            }
           

            return View(model);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        { 
            Companies companies = companyRepository.GetCompaniesById(id); 

            if (companies == null)
            {
                return HttpNotFound();
            }
            return View(companies);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Country,CreatedOnDate,LastModifiedOnDate,CreatedByUserId,LastModifiedByUserId,IsDeleted")] Companies model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.LastModifiedByUserId = User.Identity.GetUserId();
                    model.LastModifiedOnDate = DateTime.Now;
                    companyRepository.UpdateCompany(model);
                    companyRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            }
            
            return View(model);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {

            Companies companies = companyRepository.GetCompaniesById(id);
            if (companies == null)
            {
                return HttpNotFound();
            }
            return View(companies);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Companies companies = companyRepository.GetCompaniesById(id);

                companyRepository.DeleteCompany(id);
                companyRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            } 

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            companyRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
