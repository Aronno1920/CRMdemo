using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  CRM.Entity.Model
{
    public class ServiceSupplementalDetailEntity : BaseEntity
    {
        //public ServiceSupplementalDetailEntity()
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

        public int? ServiceAdditionalDetailID { get; set; }
        public virtual ServiceAdditionalDetailEntity ServiceAdditionalDetail { get; set; }
    }
}