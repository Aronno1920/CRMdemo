using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Web.ViewModel
{
    public class ChannelTypeVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        // public int CreatedBy { get; set; }
        // public int UpdatedBy { get; set; }        
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive;
        public bool? IsDeleted;
    }
}