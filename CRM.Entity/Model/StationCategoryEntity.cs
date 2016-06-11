using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  CRM.Entity.Model
{
    public class StationCategoryEntity : BaseEntity
    {
        //public StationCategoryEntity()
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

        public virtual ICollection<StationEntity> Stations { get; set; }
    }
}