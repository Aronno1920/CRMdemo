using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class StationCategoryConfiguration : EntityTypeConfiguration<StationCategoryEntity>
    {
        public StationCategoryConfiguration()
        {
            ToTable("StationCategories");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}
