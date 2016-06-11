using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class ServiceTypeDetailConfiguration : EntityTypeConfiguration<ServiceTypeDetailEntity>
    {
        public ServiceTypeDetailConfiguration()
        {
            ToTable("ServiceTypeDetails");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.ServiceTypeID).IsRequired();
        }
    }
}
