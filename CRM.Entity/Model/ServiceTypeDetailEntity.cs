using System;
using System.Collections.Generic;

namespace  CRM.Entity.Model
{
    public class ServiceTypeDetailEntity : BaseEntity
    {
        //public ServiceTypeDetailEntity()
        //{
        //    CreatedDate = DateTime.Now;
        //    IsActive = true;
        //    IsDeleted = false;
        //}
        //public int ID { get; set; }
        public string Name { get; set; }
        // public int CreatedBy { get; set; }
        // public int UpdatedBy { get; set; }        
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsDeleted { get; set; }

        public virtual ICollection<ServiceEntity> Services { get; set; }
        public virtual ICollection<ServiceAdditionalDetailEntity> ServiceAdditionalDetails { get; set; }

        public int? ServiceTypeID { get; set; }
        public virtual ServiceTypeEntity ServiceType { get; set; }
    }
}