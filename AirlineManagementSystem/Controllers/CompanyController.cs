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

namespace AirlineManagementSystem.Controllers
{
    public class CompanyController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private dbAirlineEntities db = new dbAirlineEntities();


        // GET: Company
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        //// GET: Company/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CompanyViewModel companyViewModel = db.CompanyViewModels.Find(id);
        //    if (companyViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(companyViewModel);
        //}

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Country")] Companies model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedByUserId = User.Identity.GetUserId();
                model.LastModifiedByUserId = User.Identity.GetUserId();
                model.CreatedOnDate = DateTime.Now;
                model.LastModifiedOnDate = DateTime.Now;
                model.IsDeleted = false;
                db.Companies.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companies model = db.Companies.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Country")] Companies model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //// GET: Company/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CompanyViewModel companyViewModel = db.CompanyViewModels.Find(id);
        //    if (companyViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(companyViewModel);
        //}

        //// POST: Company/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CompanyViewModel companyViewModel = db.CompanyViewModels.Find(id);
        //    db.CompanyViewModels.Remove(companyViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
