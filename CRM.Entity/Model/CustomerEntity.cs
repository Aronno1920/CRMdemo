using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace  CRM.Entity.Model
{
    public class CustomerEntity:BaseEntity
    {
        //public CustomerEntity()
        //{
        //    CreatedDate = DateTime.Now;
        //    IsActive = true;
        //    IsDeleted = false;
        //}
        //public int ID { get; set; }
        public string Code { get; set; }
        public string FrequentFlyierCode { get; set; }
        public string ProjectName { get; set; }
        public string DealerName { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OtherEmail { get; set; }

        // public int CreatedBy { get; set; }
        // public int UpdatedBy { get; set; }        
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsDeleted { get; set; }

        public int ContactTypeID { get; set; }
        public virtual ContactTypeEntity ContactType { get; set; }

        public int TitleID { get; set; }
        public virtual TitleEntity Title { get; set; }

        public int LanguageID { get; set; }
        public virtual LanguageEntity Language { get; set; }

        public int? CountryID { get; set; }
        public virtual CountryEntity Country { get; set; }

        public virtual ICollection<ProductEntity> Product { get; set; }
        public virtual ICollection<ServiceEntity> Service { get; set; }

    }
}