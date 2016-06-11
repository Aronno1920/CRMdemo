using System;

namespace  CRM.Entity.Model
{
    public class ProductEntity : BaseEntity
    {
        //public ProductEntity()
        //{
        //    CreatedDate = DateTime.Now;
        //    IsActive = true;
        //    IsDeleted = false;
        //}
        //public int ID { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public DateTime? PoPDate { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyExiredDate { get; set; }
        public string WarrantyCode { get; set; }
        public string WarrantyDescription { get; set; }
        public DateTime? ShippingDate { get; set; }

        // public int CreatedBy { get; set; }
        // public int UpdatedBy { get; set; }        
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsDeleted { get; set; }

        public int CustomerID { get; set; }
        public virtual CustomerEntity Customer { get; set; }

        public int ShippingCountryID { get; set; }
        public virtual CountryEntity ShippingCountry { get; set; }

        public int CategoryID { get; set; }
        public virtual ProductCategoryEntity Category { get; set; }

        public int TypeID { get; set; }
        public virtual ProductTypeEntity Type { get; set; }
    }
}