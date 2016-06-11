using CRM.Entity.Model;
using CRM.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CRM.Data;
using CRM.Service.Service;

namespace CRM.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICustomerService customerService;
        public SearchController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }


        // GET: Search/Create
        public ActionResult Search()
        {
            return View();
        }

        // POST: Search/Create
        [HttpPost]
        public ActionResult CreateNewCustomer(SearchVM searchvm)
        {
            try
            {
                // TODO: Add insert logic here
                CustomerEntity aCustomerEntity = new CustomerEntity();
                aCustomerEntity.FrequentFlyierCode = searchvm.FrequentFlyerID;
                aCustomerEntity.Code = searchvm.CustomerID;
                aCustomerEntity.FullName = searchvm.FullName;
                aCustomerEntity.MobileNumber = searchvm.Mobile;
                aCustomerEntity.Phone = searchvm.Phone;
                aCustomerEntity.Email = searchvm.Email;
                return RedirectToAction("CreateNew", "Customer", aCustomerEntity);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult SearchResult(string frequentFlyerId, string customerID, string fullName, string mobile, string phone, string email, string serviceCode, string productSerial, string interactionCode, string viewName)
        {
            //var customers = from c in db.Customers
            //                join s in db.Services on c.ID equals s.CustomerID
            //                join p in db.Products on c.ID equals p.CustomerID
            //                join i in db.Interactions on s.ID equals i.ServiceID
            //                where c.Code == customerID
            //                select c;

            //var customers=customerService.AllIncluding(c => c.Service, c => c.Product, c => c.Service)
            //               .Where(c => c.Code == customerID
            //                   && c.FrequentFlyierCode.Contains(frequentFlyerId)
            //                   && c.FullName.Contains(fullName)
            //                   && c.MobileNumber.Contains(mobile)
            //                   && c.Phone.Contains(phone)
            //                   && c.Email.Contains(email)
            //                   && (c.Service.ToList().Where(s => s.Code.Contains(serviceCode)).Count() > 0)
            //                   && (c.Product.ToList().Where(p => p.SerialNumber.Contains(productSerial)).Count() > 0)
            //                   );
            //model = db.Customers.Where(o => o.Code == customerID && )
            //          .OrderBy(o => o.OrderID).ToList();
            var customers = customerService.SearchCustomer(frequentFlyerId, customerID, fullName, mobile, phone, email, serviceCode, productSerial, interactionCode);

            List <CustomerEntity> customerList = customers.Distinct().ToList();
            return PartialView("_SearchResult", customerList);
        }
        
    }
}
