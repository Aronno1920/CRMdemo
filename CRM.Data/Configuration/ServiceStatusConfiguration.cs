using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class ServiceStatusConfiguration : EntityTypeConfiguration<ServiceStatusEntity>
    {
        public ServiceStatusConfiguration()
        {
            ToTable("ServiceStatus");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}
