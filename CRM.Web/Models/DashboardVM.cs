using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Web.Models
{
    public class DashboardVM
    {
        public int TotalServiceRequest { get; set; }
        public int TotalClosed { get; set; }
        public int TotalOpen { get; set; }
        public int Excalated { get; set; }
        public int MaximumAiging { get; set; }

    }
}