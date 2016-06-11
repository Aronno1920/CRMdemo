using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Entity.Model;
using CRM.Web.Models;
using CRM.Data;
using CRM.Web.Utility;

namespace CRM.Web.Controllers
{
    public class InteractionController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Interaction
        public ActionResult Index()
        {
            var interaction = db.Interactions.Include(i => i.ChannelType).Include(i => i.CurrentOutcomeCode).Include(i => i.Service);
            return View(interaction.ToList());
        }
        public PartialViewResult _serviceInteraction(int serviceID, string filter = null, int page = 1,
         int pageSize = 5, string sort = "ID", string sortdir = "DESC")
        {
            var records = new PagedList<InteractionEntity>();
            ViewBag.filter = filter;
            records.Content = db.Interactions
                       .Where(x => x.ServiceID == serviceID)
                        .OrderBy(x => x.ID)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = db.Interactions
                         .Where(x => x.ServiceID == serviceID).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;
            return PartialView("_serviceInteraction", records);
            //return View(records);
        }
        // GET: Interaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InteractionEntity interactionEntity = db.Interactions.Find(id);
            if (interactionEntity == null)
            {
                return HttpNotFound();
            }
            return View(interactionEntity);
        }

        // GET: Interaction/Create
        public ActionResult Create()
        {
            ViewBag.ChannelTypeID = new SelectList(db.ChannelTypes, "ID", "Name");
            ViewBag.CurrentOutcomeCodeID = new SelectList(db.CurrentOutcomeCode, "ID", "Name");
            ViewBag.ServiceID = new SelectList(db.Services, "ID", "Code");
            return View();
        }

        // POST: Interaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Code,ServiceID,ChannelTypeID,CurrentOutcomeCodeID,Comments,CreatedDate,UpdatedDate,IsActive,IsDeleted")] InteractionEntity interactionEntity)
        {
            if (ModelState.IsValid)
            {
                db.Interactions.Add(interactionEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChannelTypeID = new SelectList(db.ChannelTypes, "ID", "Name", interactionEntity.ChannelTypeID);
            ViewBag.CurrentOutcomeCodeID = new SelectList(db.CurrentOutcomeCode, "ID", "Name", interactionEntity.CurrentOutcomeCodeID);
            ViewBag.ServiceID = new SelectList(db.Services, "ID", "Code", interactionEntity.ServiceID);
            return View(interactionEntity);
        }

        // GET: Interaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InteractionEntity interactionEntity = db.Interactions.Find(id);
            if (interactionEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChannelTypeID = new SelectList(db.ChannelTypes, "ID", "Name", interactionEntity.ChannelTypeID);
            ViewBag.CurrentOutcomeCodeID = new SelectList(db.CurrentOutcomeCode, "ID", "Name", interactionEntity.CurrentOutcomeCodeID);
            ViewBag.ServiceID = new SelectList(db.Services, "ID", "Code", interactionEntity.ServiceID);
            return View(interactionEntity);
        }

        // POST: Interaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Code,ServiceID,ChannelTypeID,CurrentOutcomeCodeID,Comments,CreatedDate,UpdatedDate,IsActive,IsDeleted")] InteractionEntity interactionEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interactionEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChannelTypeID = new SelectList(db.ChannelTypes, "ID", "Name", interactionEntity.ChannelTypeID);
            ViewBag.CurrentOutcomeCodeID = new SelectList(db.CurrentOutcomeCode, "ID", "Name", interactionEntity.CurrentOutcomeCodeID);
            ViewBag.ServiceID = new SelectList(db.Services, "ID", "Code", interactionEntity.ServiceID);
            return View(interactionEntity);
        }

        // GET: Interaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InteractionEntity interactionEntity = db.Interactions.Find(id);
            if (interactionEntity == null)
            {
                return HttpNotFound();
            }
            return View(interactionEntity);
        }

        // POST: Interaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InteractionEntity interactionEntity = db.Interactions.Find(id);
            db.Interactions.Remove(interactionEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //For the Last Ten Interactions
        public PartialViewResult _Latest()
        {
            var interactions = db.Interactions.Include(i => i.ChannelType).Include(i => i.CurrentOutcomeCode).Include(i => i.Service).Include(i => i.Service.Customer).OrderByDescending(i=>i.ID);
            List<LatestInteractionVM> latestInteractions = new List<LatestInteractionVM>();
            LatestInteractionVM aLatestInteraction = new LatestInteractionVM();
            foreach (var item in interactions.Take(5))
            {
                aLatestInteraction = new LatestInteractionVM();
                aLatestInteraction.CustomerID = item.Service.CustomerID;
                aLatestInteraction.CustomerFullName = item.Service.Customer.FullName;
                aLatestInteraction.InteractionCreatedDate = (DateTime)item.CreatedDate;
                aLatestInteraction.ServiceCode = item.Service.Code;
                latestInteractions.Add(aLatestInteraction);
            }
            return PartialView("_latest",latestInteractions);
        }

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
