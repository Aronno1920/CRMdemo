using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class CurrentOutcomeCodeConfiguration : EntityTypeConfiguration<CurrentOutcomeCodeEntity>
    {
        public CurrentOutcomeCodeConfiguration()
        {
            ToTable("CurrentOutcomeCodes");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}
