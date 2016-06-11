using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class LanguageConfiguration : EntityTypeConfiguration<LanguageEntity>
    {
        public LanguageConfiguration()
        {
            ToTable("Languages");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.Code).IsRequired().HasMaxLength(50);
        }
    }
}
