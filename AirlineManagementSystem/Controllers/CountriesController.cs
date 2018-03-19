using System;
using System.Data;
using System.Web.Mvc;
using AirlineManagementSystem.Models;
using AirlineManagementSystem.Repositories;
using Microsoft.AspNet.Identity;

namespace AirlineManagementSystem.Controllers
{
    public class CountriesController : Controller
    {
        private dbAirlineEntities db = new dbAirlineEntities();
         

        private ICountry countryRepository;

        public CountriesController()
        {
            this.countryRepository = new CountryRepository(new dbAirlineEntities());
        }

        // GET: Countries
        [Authorize]
        public ActionResult Index()
        {
            return View(countryRepository.GetCountry());
        }

        // GET: Countries/Details/5
        //public ActionResult Details(int id)
        //{ 
        //    Country country = countryRepository.GetCountryById(id);
        //    if (country == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(country);
        //}

        // GET: Countries/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,Name,Description,CreatedOnDate,LastModifiedOnDate,CreatedByUserId,LastModifiedByUserId,IsDeleted")] Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    country.CreatedByUserId = User.Identity.GetUserId();
                    country.LastModifiedByUserId = User.Identity.GetUserId();
                    country.CreatedOnDate = DateTime.Now;
                    country.LastModifiedOnDate = DateTime.Now;
                    country.IsDeleted = false;
                    countryRepository.InsertCountry(country);
                    countryRepository.Save();

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            }
            
            return View(country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int id)
        {
            Country country = countryRepository.GetCountryById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,Name,Description,CreatedOnDate,LastModifiedOnDate,CreatedByUserId,LastModifiedByUserId,IsDeleted")] Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    country.LastModifiedByUserId = User.Identity.GetUserId();
                    country.LastModifiedOnDate = DateTime.Now;
                    countryRepository.UpdateCountry(country);
                    countryRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            }
            
            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int id)
        {
            Country country = countryRepository.GetCountryById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Country country = countryRepository.GetCountryById(id);
                countryRepository.DeleteCountry(id);
                countryRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            countryRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
