using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Configuration
{
    public class ServiceConfiguration : EntityTypeConfiguration<ServiceEntity>
    {
        public ServiceConfiguration()
        {
            ToTable("Services");
            Property(g => g.Code).IsRequired().HasMaxLength(100);
            Property(g => g.PNR).HasMaxLength(250);

            Property(g => g.CustomerID).IsRequired();
            Property(g => g.ServiceTypeID).IsRequired();
            Property(g => g.ServiceTypeDetailID).IsRequired();
            Property(g => g.ServiceAdditionalDetailID).IsRequired();
            Property(g => g.ServiceSupplementalDetailID).IsRequired();
            Property(g => g.ServiceStatusID).IsRequired();
            Property(g => g.PriorityID).IsRequired();
        }
    }
}
