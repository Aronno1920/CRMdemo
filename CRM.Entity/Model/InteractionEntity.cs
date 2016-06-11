using System;

namespace  CRM.Entity.Model
{
    public class InteractionEntity:BaseEntity
    {
        //public InteractionEntity()
        //{
        //    CreatedDate = DateTime.Now;
        //    IsActive = true;
        //    IsDeleted = false;
        //}
        //public int ID { get; set; }
        public string Code { get; set; }
        public string Comments { get; set; }
        // public int CreatedBy { get; set; }
        // public int UpdatedBy { get; set; }        
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsDeleted { get; set; }

        public int ServiceID { get; set; }
        public virtual ServiceEntity Service { get; set; }

        public int ChannelTypeID { get; set; }
        public virtual ChannelTypeEntity ChannelType { get; set; }

        public int CurrentOutcomeCodeID { get; set; }
        public virtual CurrentOutcomeCodeEntity CurrentOutcomeCode { get; set; }
    }
}