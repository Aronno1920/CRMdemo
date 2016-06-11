using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class PriorityConfiguration : EntityTypeConfiguration<PriorityEntity>
    {
        public PriorityConfiguration()
        {
            ToTable("Priorities");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}
