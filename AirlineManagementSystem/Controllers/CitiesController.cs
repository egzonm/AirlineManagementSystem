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
    public class CitiesController : Controller
    {
        //private dbAirlineEntities db = new dbAirlineEntities();

        private ICity cityRepository;

        public CitiesController()
        {
            this.cityRepository = new CityRepository(new dbAirlineEntities());
        }

        // GET: Cities
        public ActionResult Index()
        {
            return View(cityRepository.GetCity());
        }

        // GET: Cities/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cities cities = db.Cities.Find(id);
        //    if (cities == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cities);
        //}

        // GET: Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,Name,Airport_Name,Country,CreatedOnDate,LastModifiedOnDate,CreatedByUserId,LastModifiedByUserId,IsDeleted")] Cities cities)
        { 
            try
            {
                if (ModelState.IsValid)
                {
                    cities.CreatedByUserId = User.Identity.GetUserId();
                    cities.LastModifiedByUserId = User.Identity.GetUserId();
                    cities.CreatedOnDate = DateTime.Now;
                    cities.LastModifiedOnDate = DateTime.Now;
                    cities.IsDeleted = false;
                    cityRepository.InsertCity(cities);
                    cityRepository.Save();

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            } 

            return View(cities);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int id)
        {
            Cities cities = cityRepository.GetCityById(id);
            if (cities == null)
            {
                return HttpNotFound();
            }
            return View(cities);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,Name,Airport_Name,Country,CreatedOnDate,LastModifiedOnDate,CreatedByUserId,LastModifiedByUserId,IsDeleted")] Cities cities)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cities.LastModifiedByUserId = User.Identity.GetUserId();
                    cities.LastModifiedOnDate = DateTime.Now;
                    cityRepository.UpdateCity(cities);
                    cityRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            }
            
            return View(cities);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int id)
        {
            Cities cities = cityRepository.GetCityById(id);
            if (cities == null)
            {
                return HttpNotFound();
            }
            return View(cities);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Cities cities = cityRepository.GetCityById(id);
                cityRepository.DeleteCity(id);
                cityRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            cityRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
