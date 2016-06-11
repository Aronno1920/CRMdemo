using System;
using System.Collections.Generic;

namespace  CRM.Entity.Model
{
    public class FlightRouteEntity:BaseEntity
    {
        //public FlightRouteEntity()
        //{
        //    CreatedDate = DateTime.Now;
        //    IsActive = true;
        //    IsDeleted = false;
        //}
        //public int ID { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        // public int CreatedBy { get; set; }
        // public int UpdatedBy { get; set; }        
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsDeleted { get; set; }

        public virtual ICollection<ServiceEntity> Services { get; set; }

        public int FlightRouteCategoryID { get; set; }
        public virtual FlightRouteCategoryEntity FlightRouteCategory { get; set; }
    }
}