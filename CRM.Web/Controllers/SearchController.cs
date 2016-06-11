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
            var customers = customerService.SearchCustomer(frequentFlyerId, customerID, fullName, mobile, phone, email, serviceCode, productSerial, interactionCode);

            List <CustomerEntity> customerList = customers.Distinct().ToList();
            return PartialView("_SearchResult", customerList);
        }
        
    }
}
