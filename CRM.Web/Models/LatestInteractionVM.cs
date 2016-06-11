using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Web.Models
{
    public class LatestInteractionVM
    {
        public int CustomerID { get; set; }
        public string CustomerFullName { get; set; }
        public string ServiceCode { get; set; }
        public DateTime InteractionCreatedDate { get; set; }
    }
}