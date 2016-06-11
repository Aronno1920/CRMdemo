using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class ServiceAdditionalDetailConfiguration : EntityTypeConfiguration<ServiceAdditionalDetailEntity>
    {
        public ServiceAdditionalDetailConfiguration()
        {
            ToTable("ServiceAdditionalDetails");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.ServiceTypeDetailID).IsRequired();
        }
    }
}
