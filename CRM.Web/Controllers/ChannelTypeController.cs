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
using CRM.Data.Infrastructure;
using Microsoft.AspNet.Identity;

namespace CRM.Web.Controllers
{
    public class ChannelTypeController : Controller
    {
        private readonly ICRMService<ChannelTypeEntity> channelTypeService;
        public ChannelTypeController(ICRMService<ChannelTypeEntity> channelTypeService)
        {
            this.channelTypeService = channelTypeService;
        }

        // GET: City
        public ActionResult Index()
        {
            return View(channelTypeService.GetMany(r => r.IsDeleted == false).ToList());
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelTypeEntity channelTypeEntity = channelTypeService.GetById(id);
            if (channelTypeEntity == null)
            {
                return HttpNotFound();
            }
            return View(channelTypeEntity);
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
        public ActionResult Create([Bind(Include = "ID,Name,CreatedDate,UpdatedDate,IsActive,IsDeleted,CreatedByID,UpdatedByID")] ChannelTypeEntity channelTypeEntity)
        {
            if (ModelState.IsValid)
            {
                channelTypeEntity.CreatedByID = User.Identity.GetUserId();
                channelTypeService.Add(channelTypeEntity);
                channelTypeService.Save();
                return RedirectToAction("Index");
            }
            return View(channelTypeEntity);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelTypeEntity channelTypeEntity = channelTypeService.GetById(id);
            if (channelTypeEntity == null)
            {
                return HttpNotFound();
            }
            return View(channelTypeEntity);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CreatedDate,UpdatedDate,IsActive,IsDeleted,CreatedByID,UpdatedByID")] ChannelTypeEntity channelTypeEntity)
        {
            if (ModelState.IsValid)
            {
                // channelTypeService.Entry(channelTypeEntity).State = EntityState.Modified;
                ChannelTypeEntity channelTypeEntityOLD = channelTypeService.GetById(channelTypeEntity.ID);
                channelTypeEntityOLD.UpdatedByID = User.Identity.GetUserId();
                channelTypeEntityOLD.UpdatedDate = DateTime.Now;
                channelTypeEntityOLD.IsActive = channelTypeEntity.IsActive;
                channelTypeEntityOLD.Name = channelTypeEntity.Name;
                channelTypeService.Update(channelTypeEntityOLD);
                channelTypeService.Save();
                return RedirectToAction("Index");
            }
            return View(channelTypeEntity);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelTypeEntity channelTypeEntity = channelTypeService.GetById(id);
            if (channelTypeEntity == null)
            {
                return HttpNotFound();
            }
            return View(channelTypeEntity);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChannelTypeEntity channelTypeEntity = channelTypeService.GetById(id);
            channelTypeEntity.IsDeleted = true;
            channelTypeEntity.UpdatedByID = User.Identity.GetUserId();
            channelTypeEntity.UpdatedDate = DateTime.Now;
            channelTypeService.Save();
            return RedirectToAction("Index");
        }

        // POST: City/Active/5
        public ActionResult Active(int id)
        {
            ChannelTypeEntity channelTypeEntity = channelTypeService.GetById(id);
            if (channelTypeEntity.IsActive == true)
                channelTypeEntity.IsActive = false;
            else
                channelTypeEntity.IsActive = true;

            channelTypeService.Save();
            return RedirectToAction("Index");
        }
    }
}
