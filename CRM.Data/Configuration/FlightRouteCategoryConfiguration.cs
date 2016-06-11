using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class FlightRouteCategoryConfiguration : EntityTypeConfiguration<FlightRouteCategoryEntity>
    {
        public FlightRouteCategoryConfiguration()
        {
            ToTable("FlightRouteCategories");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}
