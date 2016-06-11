using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CRM.Entity.Model;
using CRM.Data;
using CRM.Web.Utility;

namespace CRM.Web.Controllers
{
    public class ServiceController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Service
        public ActionResult Index()
        {
            var services = db.Services.Include(s => s.City).Include(s => s.Country).Include(s => s.Customer).Include(s => s.FlightRoute).Include(s => s.Priority).Include(s => s.ServiceAdditionalDetail).Include(s => s.ServiceCenter).Include(s => s.ServiceStatus).Include(s => s.ServiceSupplementalDetail).Include(s => s.ServiceType).Include(s => s.ServiceTypeDetail).Include(s => s.Station);
            return View(services.ToList());
        }
        public PartialViewResult _customerService(int customerID, string filter = null, int page = 1,
         int pageSize = 5, string sort = "ID", string sortdir = "DESC")
        {
            var records = new PagedList<ServiceEntity>();
            ViewBag.filter = filter;
            records.Content = db.Services
                       .Where(x => x.CustomerID == customerID)
                        .OrderBy(x => x.ID)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = db.Services
                         .Where(x => x.CustomerID == customerID).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;
            return PartialView("_customerService", records);
            //return View(records);
        }
        // GET: Service/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceEntity serviceEntity = db.Services.Find(id);
            if (serviceEntity == null)
            {
                return HttpNotFound();
            }
            return View(serviceEntity);
        }

        // GET: Service/Create
        public ActionResult Create(int? customerID = null)
        {
            ServiceEntity aServiceEntity = new ServiceEntity();
            if (customerID != null)
                aServiceEntity.CustomerID = (int)customerID;

            ViewBag.CityID = new SelectList(db.Citys, "ID", "Name");
            ViewBag.CountryID = new SelectList(db.Countrys, "ID", "Code");
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Code");
            ViewBag.FlightRouteID = new SelectList(db.FlightRoutes, "ID", "Origin");
            ViewBag.PriorityID = new SelectList(db.Prioritys, "ID", "Name");
            ViewBag.ServiceAdditionalDetailID = new SelectList(db.ServiceAdditionalDetails, "ID", "Name");
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name");
            ViewBag.ServiceStatusID = new SelectList(db.ServiceStatuses, "ID", "Name");
            ViewBag.ServiceSupplementalDetailID = new SelectList(db.ServiceSupplementalDetails, "ID", "Name");
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ID", "Name");
            ViewBag.ServiceTypeDetailID = new SelectList(db.ServiceTypeDetails, "ID", "Name");
            ViewBag.StationID = new SelectList(db.Stations, "ID", "Name");
            return View(aServiceEntity);
        }

        // POST: Service/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Code,CustomerID,ServiceTypeID,ServiceTypeDetailID,ServiceAdditionalDetailID,ServiceSupplementalDetailID,ServiceStatusID,PriorityID,CountryID,ServiceCenterID,OnsiteAppointmentDate,CityID,FlightRouteID,StationID,PNR,ClosedDate,CreatedDate,UpdatedDate,IsActive,IsDeleted")] ServiceEntity serviceEntity)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(serviceEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Citys, "ID", "Name", serviceEntity.CityID);
            ViewBag.CountryID = new SelectList(db.Countrys, "ID", "Code", serviceEntity.CountryID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Code", serviceEntity.CustomerID);
            ViewBag.FlightRouteID = new SelectList(db.FlightRoutes, "ID", "Origin", serviceEntity.FlightRouteID);
            ViewBag.PriorityID = new SelectList(db.Prioritys, "ID", "Name", serviceEntity.PriorityID);
            ViewBag.ServiceAdditionalDetailID = new SelectList(db.ServiceAdditionalDetails, "ID", "Name", serviceEntity.ServiceAdditionalDetailID);
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", serviceEntity.ServiceCenterID);
            ViewBag.ServiceStatusID = new SelectList(db.ServiceStatuses, "ID", "Name", serviceEntity.ServiceStatusID);
            ViewBag.ServiceSupplementalDetailID = new SelectList(db.ServiceSupplementalDetails, "ID", "Name", serviceEntity.ServiceSupplementalDetailID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ID", "Name", serviceEntity.ServiceTypeID);
            ViewBag.ServiceTypeDetailID = new SelectList(db.ServiceTypeDetails, "ID", "Name", serviceEntity.ServiceTypeDetailID);
            ViewBag.StationID = new SelectList(db.Stations, "ID", "Name", serviceEntity.StationID);
            return View(serviceEntity);
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceEntity serviceEntity = db.Services.Find(id);
            if (serviceEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Citys, "ID", "Name", serviceEntity.CityID);
            ViewBag.CountryID = new SelectList(db.Countrys, "ID", "Code", serviceEntity.CountryID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Code", serviceEntity.CustomerID);
            ViewBag.FlightRouteID = new SelectList(db.FlightRoutes, "ID", "Origin", serviceEntity.FlightRouteID);
            ViewBag.PriorityID = new SelectList(db.Prioritys, "ID", "Name", serviceEntity.PriorityID);
            ViewBag.ServiceAdditionalDetailID = new SelectList(db.ServiceAdditionalDetails, "ID", "Name", serviceEntity.ServiceAdditionalDetailID);
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", serviceEntity.ServiceCenterID);
            ViewBag.ServiceStatusID = new SelectList(db.ServiceStatuses, "ID", "Name", serviceEntity.ServiceStatusID);
            ViewBag.ServiceSupplementalDetailID = new SelectList(db.ServiceSupplementalDetails, "ID", "Name", serviceEntity.ServiceSupplementalDetailID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ID", "Name", serviceEntity.ServiceTypeID);
            ViewBag.ServiceTypeDetailID = new SelectList(db.ServiceTypeDetails, "ID", "Name", serviceEntity.ServiceTypeDetailID);
            ViewBag.StationID = new SelectList(db.Stations, "ID", "Name", serviceEntity.StationID);
            return View(serviceEntity);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Code,CustomerID,ServiceTypeID,ServiceTypeDetailID,ServiceAdditionalDetailID,ServiceSupplementalDetailID,ServiceStatusID,PriorityID,CountryID,ServiceCenterID,OnsiteAppointmentDate,CityID,FlightRouteID,StationID,PNR,ClosedDate,CreatedDate,UpdatedDate,IsActive,IsDeleted")] ServiceEntity serviceEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Citys, "ID", "Name", serviceEntity.CityID);
            ViewBag.CountryID = new SelectList(db.Countrys, "ID", "Code", serviceEntity.CountryID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Code", serviceEntity.CustomerID);
            ViewBag.FlightRouteID = new SelectList(db.FlightRoutes, "ID", "Origin", serviceEntity.FlightRouteID);
            ViewBag.PriorityID = new SelectList(db.Prioritys, "ID", "Name", serviceEntity.PriorityID);
            ViewBag.ServiceAdditionalDetailID = new SelectList(db.ServiceAdditionalDetails, "ID", "Name", serviceEntity.ServiceAdditionalDetailID);
            ViewBag.ServiceCenterID = new SelectList(db.ServiceCenters, "ID", "Name", serviceEntity.ServiceCenterID);
            ViewBag.ServiceStatusID = new SelectList(db.ServiceStatuses, "ID", "Name", serviceEntity.ServiceStatusID);
            ViewBag.ServiceSupplementalDetailID = new SelectList(db.ServiceSupplementalDetails, "ID", "Name", serviceEntity.ServiceSupplementalDetailID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ID", "Name", serviceEntity.ServiceTypeID);
            ViewBag.ServiceTypeDetailID = new SelectList(db.ServiceTypeDetails, "ID", "Name", serviceEntity.ServiceTypeDetailID);
            ViewBag.StationID = new SelectList(db.Stations, "ID", "Name", serviceEntity.StationID);
            return View(serviceEntity);
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceEntity serviceEntity = db.Services.Find(id);
            if (serviceEntity == null)
            {
                return HttpNotFound();
            }
            return View(serviceEntity);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceEntity serviceEntity = db.Services.Find(id);
            db.Services.Remove(serviceEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get Type Details DDL Data
        //It is necessary to set string type in parameter or else you will get Internal Server error 500.
        [HttpPost]
        public JsonResult GetDDLdata(string typeSelected,string ddlType)
        {
            int type = int.Parse(typeSelected);
            List<SelectListItem> list = new List<SelectListItem>();

            switch (ddlType)
            {
                case "typeDetail":
                    var typeDetails = from std in db.ServiceTypeDetails
                                      where std.ServiceTypeID == type
                                      select std;

                    list.Add(new SelectListItem() { Value = "", Text = "-- Please Select --" });

                    foreach (var item in typeDetails)
                    {
                        list.Add(new SelectListItem() { Value = item.ID.ToString(), Text = item.Name });
                    }
                    break;

                case "additionalDetail":
                    var additionalDetails = from std in db.ServiceAdditionalDetails
                                      where std.ServiceTypeDetailID == type
                                      select std;
                    list.Add(new SelectListItem() { Value = "", Text = "-- Please Select --" });
                    foreach (var item in additionalDetails)
                    {
                        list.Add(new SelectListItem() { Value = item.ID.ToString(), Text = item.Name });
                    }
                    break;

                case "supplementalDetail":
                    var supplementalDetails = from std in db.ServiceSupplementalDetails
                                      where std.ServiceAdditionalDetailID == type
                                      select std;
                    list.Add(new SelectListItem() { Value = "", Text = "-- Please Select --" });
                    foreach (var item in supplementalDetails)
                    {
                        list.Add(new SelectListItem() { Value = item.ID.ToString(), Text = item.Name });
                    }
                    break;


                default:
                    break;
            }
           
            return Json(list, JsonRequestBehavior.AllowGet);
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
