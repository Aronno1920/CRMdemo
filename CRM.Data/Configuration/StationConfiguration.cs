using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class StationConfiguration : EntityTypeConfiguration<StationEntity>
    {
        public StationConfiguration()
        {
            ToTable("Stations");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.Utc).IsRequired().HasMaxLength(100);
            Property(g => g.StationCategoryID).IsRequired();
        }
    }
}
