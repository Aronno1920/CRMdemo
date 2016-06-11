using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class ServiceTypeConfiguration : EntityTypeConfiguration<ServiceTypeEntity>
    {
        public ServiceTypeConfiguration()
        {
            ToTable("ServiceTypes");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}
