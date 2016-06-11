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
using Microsoft.AspNet.Identity;

namespace CRM.Web.Controllers
{
    public class CityTypeController : Controller
    {
        private readonly ICRMService<CityTypeEntity> cityTypeService;
        public CityTypeController(ICRMService<CityTypeEntity> cityTypeService)
        {
            this.cityTypeService = cityTypeService;
        }

        // GET: City
        public ActionResult Index()
        {
            return View(cityTypeService.GetMany(r => r.IsDeleted == false).ToList());
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityTypeEntity cityTypeEntity = cityTypeService.GetById(id);
            if (cityTypeEntity == null)
            {
                return HttpNotFound();
            }
            return View(cityTypeEntity);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CreatedDate,UpdatedDate,IsActive,IsDeleted,CreatedByID,UpdatedByID")] CityTypeEntity cityTypeEntity)
        {
            if (ModelState.IsValid)
            {
                cityTypeEntity.CreatedByID = User.Identity.GetUserId();
                cityTypeService.Add(cityTypeEntity);
                cityTypeService.Save();
                return RedirectToAction("Index");
            }
            return View(cityTypeEntity);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityTypeEntity cityTypeEntity = cityTypeService.GetById(id);
            if (cityTypeEntity == null)
            {
                return HttpNotFound();
            }
            return View(cityTypeEntity);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,IsActive,IsDeleted")] CityTypeEntity cityTypeEntity)
        {
            if (ModelState.IsValid)
            {
                // cityTypeService.Entry(cityTypeEntity).State = EntityState.Modified;
                CityTypeEntity cityTypeEntityOLD = cityTypeService.GetById(cityTypeEntity.ID);
                cityTypeEntityOLD.UpdatedByID = User.Identity.GetUserId();
                cityTypeEntityOLD.UpdatedDate = DateTime.Now;
                cityTypeEntityOLD.IsActive = cityTypeEntity.IsActive;
                cityTypeEntityOLD.Name = cityTypeEntity.Name;
                cityTypeService.Update(cityTypeEntityOLD);
                cityTypeService.Save();
                return RedirectToAction("Index");
            }
            return View(cityTypeEntity);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityTypeEntity cityTypeEntity = cityTypeService.GetById(id);
            if (cityTypeEntity == null)
            {
                return HttpNotFound();
            }
            return View(cityTypeEntity);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityTypeEntity cityTypeEntity = cityTypeService.GetById(id);
            cityTypeEntity.IsDeleted = true;
            cityTypeEntity.UpdatedByID = User.Identity.GetUserId();
            cityTypeEntity.UpdatedDate = DateTime.Now;
            cityTypeService.Save();
            return RedirectToAction("Index");
        }

        // POST: City/Active/5
        public ActionResult Active(int id)
        {
            CityTypeEntity cityTypeEntity = cityTypeService.GetById(id);
            if (cityTypeEntity.IsActive == true)
                cityTypeEntity.IsActive = false;
            else
                cityTypeEntity.IsActive = true;

            cityTypeService.Save();
            return RedirectToAction("Index");
        }
    }
}
