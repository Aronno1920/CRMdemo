using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Web.Models
{
    public class SearchResultVM
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int FrequentFlyerID { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}