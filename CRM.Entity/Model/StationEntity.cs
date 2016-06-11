using System;
using System.Collections.Generic;

namespace  CRM.Entity.Model
{
    public class StationEntity : BaseEntity
    {
        //public StationEntity()
        //{
        //    CreatedDate = DateTime.Now;
        //    IsActive = true;
        //    IsDeleted = false;
        //}
        //public int ID { get; set; }
        public string Name { get; set; }
        public string Utc { get; set; }
        // public int CreatedBy { get; set; }
        // public int UpdatedBy { get; set; }        
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsDeleted { get; set; }

        public virtual ICollection<ServiceEntity> Services { get; set; }

        public int StationCategoryID { get; set; }
        public virtual StationCategoryEntity StationCategory { get; set; }
    }
}