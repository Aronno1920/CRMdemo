using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Web.Models
{
    public class SearchVM
    {
        public string FrequentFlyerID { get; set; }
        public string CustomerID { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "{0} is not valid")]
        public string Mobile { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} is not valid")]
        public string Email { get; set; }
        public string ServiceCode { get; set; }
        public string ProductSerial { get; set; }
        public string InteractionCode { get; set; }

    }
    //public class SearchResult
    //{
    //    public int ID { get; set; }
    //    public string FullName { get; set; }
    //    public int FrequentFlyerID { get; set; }
    //    public string Mobile { get; set; }
    //    public string Email { get; set; }
    //}
    //public class LatestInteraction
    //{
    //    public int CustomerID { get; set; }
    //    public string CustomerFullName { get; set; }
    //    public string ServiceCode { get; set; }
    //    public DateTime InteractionCreatedDate { get; set; }
    //}
}