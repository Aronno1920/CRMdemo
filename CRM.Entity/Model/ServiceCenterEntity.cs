using System;
using System.Collections.Generic;

namespace  CRM.Entity.Model
{
    public class ServiceCenterEntity : BaseEntity
    {
        //public ServiceCenterEntity()
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

        public int CountryID { get; set; }
        public virtual CountryEntity Country { get; set; }
    }
}