using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CRM.Entity.Model;
using CRM.Web.Models;
using CRM.Data;
using System;

namespace CRM.Web.Controllers
{
    public class CustomerServiceController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Customer
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.ContactType).Include(c => c.Country).Include(c => c.Language).Include(c => c.Title);
            return View(customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEntity customerEntity = db.Customers.Find(id);
            if (customerEntity == null)
            {
                return HttpNotFound();
            }
            return View(customerEntity);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var interactions = db.Interactions.ToList();
            var contactTypes = db.ContactTypes.ToList();
            List<SelectListItem> contactTypeList = new List<SelectListItem>();
            contactTypeList.Add(new SelectListItem()
            {
                Text = "-- Please Select --",
                Value = "0"
            });
            foreach (var item in contactTypes)
            {
                contactTypeList.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.ID.ToString()
                });
            }

            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ID", "Name");
            ViewBag.CountryID = new SelectList(db.Countrys, "ID", "Code");
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "Code");
            ViewBag.TitleID = new SelectList(db.Titles, "ID", "Name");
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Code,FrequentFlyier_Code,ProjectName,DealerName,ContactTypeID,TitleID,FullName,MobileNumber,Phone,Email,OtherEmail,LanguageID,CountryID,UpdatedDate,CreatedDate,IsActive,IsDeleted")] CustomerEntity customerEntity)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customerEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ID", "Name", customerEntity.ContactTypeID);
            ViewBag.CountryID = new SelectList(db.Countrys, "ID", "Code", customerEntity.CountryID);
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "Code", customerEntity.LanguageID);
            ViewBag.TitleID = new SelectList(db.Titles, "ID", "Name", customerEntity.TitleID);
            return View(customerEntity);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEntity customerEntity = db.Customers.Find(id);
            if (customerEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ID", "Name", customerEntity.ContactTypeID);
            ViewBag.CountryID = new SelectList(db.Countrys, "ID", "Code", customerEntity.CountryID);
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "Code", customerEntity.LanguageID);
            ViewBag.TitleID = new SelectList(db.Titles, "ID", "Name", customerEntity.TitleID);
            return View(customerEntity);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Code,FrequentFlyier_Code,ProjectName,DealerName,ContactTypeID,TitleID,FullName,MobileNumber,Phone,Email,OtherEmail,LanguageID,CountryID,UpdatedDate,CreatedDate,IsActive,IsDeleted")] CustomerEntity customerEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ID", "Name", customerEntity.ContactTypeID);
            ViewBag.CountryID = new SelectList(db.Countrys, "ID", "Code", customerEntity.CountryID);
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "Code", customerEntity.LanguageID);
            ViewBag.TitleID = new SelectList(db.Titles, "ID", "Name", customerEntity.TitleID);
            return View(customerEntity);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEntity customerEntity = db.Customers.Find(id);
            if (customerEntity == null)
            {
                return HttpNotFound();
            }
            return View(customerEntity);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerEntity customerEntity = db.Customers.Find(id);
            db.Customers.Remove(customerEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            var interactions = db.Interactions.Include(i => i.ChannelType).Include(i => i.CurrentOutcomeCode).Include(i => i.Service).Include(i=>i.Service.Customer);
            List<LatestInteractionVM> latestInteractions = new List<LatestInteractionVM>();
            LatestInteractionVM aLatestInteraction = new LatestInteractionVM();
            foreach (var item in interactions)
            {
                aLatestInteraction = new LatestInteractionVM();
                aLatestInteraction.CustomerID = item.Service.CustomerID;
                aLatestInteraction.CustomerFullName = item.Service.Customer.FullName;
                aLatestInteraction.InteractionCreatedDate =(DateTime) item.CreatedDate;
                aLatestInteraction.ServiceCode = item.Service.Code;
                latestInteractions.Add(aLatestInteraction);
            }
            return View(latestInteractions);
        }
        public ActionResult SearchResult(string frequentFlyerId, string customerID, string fullName, string mobile, string phone, string email,string serviceCode, string productSerial, string interactionCode, string viewName)
        {
            
            var customers = from c in db.Customers
                    join s in db.Services on c.ID equals s.CustomerID
                    join p in db.Products on c.ID equals p.CustomerID
                    join i in db.Interactions on s.ID equals i.ServiceID
                    where c.Code == customerID
                    select c;
            //model = db.Customers.Where(o => o.Code == customerID && )
            //          .OrderBy(o => o.OrderID).ToList();
            List<CustomerEntity> a = customers.Distinct().ToList();
            return PartialView("SearchResult", a);
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
