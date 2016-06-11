using CRM.Entity.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity.Model
{
   public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public string CreatedByID { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }

        public string UpdatedByID { get; set; }
        public virtual ApplicationUser UpdatedBy { get; set; }
    }
}
