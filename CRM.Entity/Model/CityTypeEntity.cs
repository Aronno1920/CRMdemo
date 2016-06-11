using CRM.Entity.Authentication;
using System;
using System.Collections.Generic;

namespace  CRM.Entity.Model
{
    public class CityTypeEntity:BaseEntity
    {
        //public CityTypeEntity()
        //{
        //    CreatedDate = DateTime.Now;
        //    IsActive = true;
        //    IsDeleted = false;
        //}
        //public int ID { get; set; }
        //public string Name { get; set; }       
        //public DateTime CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsDeleted { get; set; }

        //public string CreatedByID { get; set; }
        //public virtual ApplicationUser CreatedBy { get; set; }

        //public string UpdatedByID { get; set; }
        //public virtual ApplicationUser UpdatedBy { get; set; }


        public string Name { get; set; }

        public virtual ICollection<CityEntity> Cities { get; set; }
    }
}