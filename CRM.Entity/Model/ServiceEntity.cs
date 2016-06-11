using System;
using System.Collections.Generic;

namespace  CRM.Entity.Model
{
    public class ServiceEntity : BaseEntity
    {
        //public ServiceEntity()
        //{
        //    CreatedDate = DateTime.Now;
        //    IsActive = true;
        //    IsDeleted = false;
        //}
        //public int ID { get; set; }
        public string Code { get; set; } 
        public DateTime? OnsiteAppointmentDate { get; set; }
        public string PNR { get; set; }

        public DateTime? ClosedDate { get; set; }
        // public int CreatedBy { get; set; }
        // public int UpdatedBy { get; set; }
        // public int EscalatedTo { get; set; }
        // public int ClosedBy { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsDeleted { get; set; }

        public int CustomerID { get; set; }
        public virtual CustomerEntity Customer { get; set; }

        public int ServiceTypeID { get; set; }
        public virtual ServiceTypeEntity ServiceType { get; set; }

        public int ServiceTypeDetailID { get; set; }
        public virtual ServiceTypeDetailEntity ServiceTypeDetail { get; set; }

        public int ServiceAdditionalDetailID { get; set; }
        public virtual ServiceAdditionalDetailEntity ServiceAdditionalDetail { get; set; }

        public int ServiceSupplementalDetailID { get; set; }
        public virtual ServiceSupplementalDetailEntity ServiceSupplementalDetail { get; set; }

        public int ServiceStatusID { get; set; }
        public virtual ServiceStatusEntity ServiceStatus { get; set; }

        public int PriorityID { get; set; }
        public virtual PriorityEntity Priority { get; set; }

        public int? CountryID { get; set; }
        public virtual CountryEntity Country { get; set; }

        public int ServiceCenterID { get; set; }
        public virtual ServiceCenterEntity ServiceCenter { get; set; }

        public int CityID { get; set; }
        public virtual CityEntity City { get; set; }

        public int FlightRouteID { get; set; }
        public virtual FlightRouteEntity FlightRoute { get; set; }

        public int StationID { get; set; }
        public virtual StationEntity Station { get; set; }

        public virtual ICollection<InteractionEntity> Interactions { get; set; }
    }
}