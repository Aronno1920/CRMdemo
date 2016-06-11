using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class ServiceCenterConfiguration : EntityTypeConfiguration<ServiceCenterEntity>
    {
        public ServiceCenterConfiguration()
        {
            ToTable("ServiceCenters");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.CountryID).IsRequired();
        }
    }
}
