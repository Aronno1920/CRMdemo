using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class TitleConfiguration: EntityTypeConfiguration<TitleEntity>
    {
        public TitleConfiguration()
        {
            ToTable("Titles");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}
