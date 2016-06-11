using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Entity.Model;
using CRM.Web.Utility;
using CRM.Data;

namespace CRM.Web.Controllers
{
    public class ProductController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: Product
        public ActionResult Index2()
        {
            var products = db.Products.Include(p => p.Customer).Include(p => p.ShippingCountry);
            return View(products.ToList());
        }
        public ActionResult Index(string filter = null, int page = 1,
         int pageSize = 5, string sort = "ID", string sortdir = "DESC")
        {
            var records = new PagedList<ProductEntity>();
            ViewBag.filter = filter;
            records.Content = db.Products
                        .Where(x => filter == null ||
                                (x.Model.Contains(filter))
                                   || x.SerialNumber.Contains(filter)
                              )
                        .OrderBy(x=>x.ID)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = db.Products
                         .Where(x => filter == null ||
                               (x.Model.Contains(filter)) || x.SerialNumber.Contains(filter)).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }

        public PartialViewResult _customerProduct(int customerID, string filter = null, int page = 1,
         int pageSize = 5, string sort = "ID", string sortdir = "DESC")
        {
            var records = new PagedList<ProductEntity>();
            ViewBag.filter = filter;
            records.Content = db.Products
                       .Where(x => x.CustomerID == customerID)
                        .OrderBy(x => x.ID)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = db.Products
                         .Where(x => x.CustomerID == customerID).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;
            return PartialView("_customerProduct", records);
            //return View(records);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEntity productEntity = db.Products.Find(id);
            if (productEntity == null)
            {
                return HttpNotFound();
            }
            return View(productEntity);
        }

        // GET: Product/Create
        public ActionResult Create(int? customerID=null)
        {
            ProductEntity aProductEntity = new ProductEntity();
            if(customerID !=null)
            aProductEntity.CustomerID = (int)customerID;
            ViewBag.CategoryID = new SelectList(db.ProductCategorys, "ID", "Name");
            ViewBag.TypeID = new SelectList(db.ProductTypes, "ID", "Name");
            ViewBag.ShippingCountryID = new SelectList(db.Countrys, "ID", "Name");
            return View(aProductEntity);
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SerialNumber,CustomerID,TypeID,CategoryID,Model,PoPDate,WarrantyStartDate,WarrantyExiredDate,WarrantyCode,WarrantyDescription,ShippingDate,ShippingCountryID,CreatedDate,UpdatedDate,IsActive,IsDeleted")] ProductEntity productEntity)
        {
           
            if (ModelState.IsValid)
            {
                db.Products.Add(productEntity);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = productEntity.ID } );
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategorys, "ID", "Name", productEntity.CategoryID);
            ViewBag.TypeID = new SelectList(db.ProductTypes, "ID", "Name", productEntity.TypeID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "FullName", productEntity.CustomerID);
            ViewBag.ShippingCountryID = new SelectList(db.Countrys, "ID", "Name", productEntity.ShippingCountryID);
            return View(productEntity);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEntity productEntity = db.Products.Find(id);
            if (productEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategorys, "ID", "Name", productEntity.CategoryID);
            ViewBag.TypeID = new SelectList(db.ProductTypes, "ID", "Name", productEntity.TypeID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "FullName", productEntity.CustomerID);
            ViewBag.ShippingCountryID = new SelectList(db.Countrys, "ID", "Name", productEntity.ShippingCountryID);
            return View(productEntity);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SerialNumber,CustomerID,TypeID,CategoryID,Model,PoPDate,WarrantyStartDate,WarrantyExiredDate,WarrantyCode,WarrantyDescription,ShippingDate,ShippingCountryID,CreatedDate,UpdatedDate,IsActive,IsDeleted")] ProductEntity productEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = productEntity.ID });
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategorys, "ID", "Name", productEntity.CategoryID);
            ViewBag.TypeID = new SelectList(db.ProductTypes, "ID", "Name", productEntity.TypeID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "FullName", productEntity.CustomerID);
            ViewBag.ShippingCountryID = new SelectList(db.Countrys, "ID", "Name", productEntity.ShippingCountryID);
            return View(productEntity);
        }
        // POST: Product/EditDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetails(int id=0)
        {
            return RedirectToAction("Details", new { id =id });           
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductEntity productEntity = db.Products.Find(id);
            if (productEntity == null)
            {
                return HttpNotFound();
            }
            return View(productEntity);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductEntity productEntity = db.Products.Find(id);
            db.Products.Remove(productEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
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
