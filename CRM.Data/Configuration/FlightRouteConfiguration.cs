using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class FlightRouteConfiguration : EntityTypeConfiguration<FlightRouteEntity>
    {
        public FlightRouteConfiguration()
        {
            ToTable("FlightRoutes");
            Property(g => g.Origin).IsRequired().HasMaxLength(100);
            Property(g => g.Destination).IsRequired().HasMaxLength(100);
            Property(g => g.FlightRouteCategoryID).IsRequired();
        }
    }
}
