using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Data;
using CRM.Entity.Model;
using CRM.Service.Service;
using CRM.Entity.Authentication;
using Microsoft.AspNet.Identity;

namespace CRM.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly ICRMService<CityEntity> cityService;
        private readonly ICRMService<CityTypeEntity> cityTypeService;
        public CityController(ICRMService<CityEntity> cityService, ICRMService<CityTypeEntity> cityTypeService)
        {
            this.cityService = cityService;
            this.cityTypeService = cityTypeService;
        }

        // GET: City
        public ActionResult Index()
        {
           return View(cityService.GetMany(r=>r.IsDeleted==false).ToList());
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityEntity cityEntity = cityService.GetById(id);
            if (cityEntity == null)
            {
                return HttpNotFound();
            }
            return View(cityEntity);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            ViewBag.CityTypeID = new SelectList(cityTypeService.GetMany(e => e.IsActive == true && e.IsDeleted == false), "ID", "Name");
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CreatedDate,UpdatedDate,IsActive,IsDeleted,CityTypeID,CreatedByID,UpdatedByID")] CityEntity cityEntity)
        {
            if (ModelState.IsValid)
            {
                cityEntity.CreatedByID= User.Identity.GetUserId();
                cityService.Add(cityEntity);
                cityService.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CityTypeID = new SelectList(cityTypeService.GetMany(e => e.IsActive == true && e.IsDeleted == false), "ID", "Name");
            return View(cityEntity);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityEntity cityEntity = cityService.GetById(id);
            if (cityEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityTypeID = new SelectList(cityTypeService.GetMany(e => e.IsActive == true && e.IsDeleted==false), "ID", "Name", cityEntity.CityTypeID);
            return View(cityEntity);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CreatedDate,UpdatedDate,IsActive,IsDeleted,CityTypeID,CreatedByID,UpdatedByID")] CityEntity cityEntity)
        {
            if (ModelState.IsValid)
            {
                // cityService.Entry(cityEntity).State = EntityState.Modified;
                CityEntity cityEntityOLD = cityService.GetById(cityEntity.ID);
                cityEntityOLD.UpdatedByID = User.Identity.GetUserId();
                cityEntityOLD.UpdatedDate = DateTime.Now;
                cityEntityOLD.IsActive = cityEntity.IsActive;
                cityEntityOLD.Name = cityEntity.Name;
                cityEntity.UpdatedByID = User.Identity.GetUserId();
                cityEntity.UpdatedDate = DateTime.Now;
                cityService.Update(cityEntityOLD);
                cityService.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CityTypeID = new SelectList(cityTypeService.GetMany(e => e.IsActive == true && e.IsDeleted == false), "ID", "Name");
            return View(cityEntity);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityEntity cityEntity = cityService.GetById(id);
            if (cityEntity == null)
            {
                return HttpNotFound();
            }
            return View(cityEntity);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityEntity cityEntity = cityService.GetById(id);
            cityEntity.IsDeleted = true;
            cityEntity.UpdatedByID = User.Identity.GetUserId();
            cityEntity.UpdatedDate = DateTime.Now;
            cityService.Save();
            return RedirectToAction("Index");
        }

        // POST: City/Active/5
        public ActionResult Active(int id)
        {
            CityEntity cityEntity = cityService.GetById(id);
            if (cityEntity.IsActive == true)
                cityEntity.IsActive = false;
            else
                cityEntity.IsActive = true;

            cityService.Save();
            return RedirectToAction("Index");
        }
    }
}
