using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class ServiceSupplementalDetailConfiguration : EntityTypeConfiguration<ServiceSupplementalDetailEntity>
    {
        public ServiceSupplementalDetailConfiguration()
        {
            ToTable("ServiceSupplementalDetails");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.ServiceAdditionalDetailID).IsRequired();
        }
    }
}
