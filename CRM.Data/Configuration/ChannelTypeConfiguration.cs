using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class ChannelTypeConfiguration: EntityTypeConfiguration<ChannelTypeEntity>
    {
        public ChannelTypeConfiguration()
        {
            ToTable("ChannelTypes");
            Property(g => g.Name).IsRequired().HasMaxLength(50);

            HasOptional(m => m.CreatedBy)
                       .WithMany(t => t.ChannelTypeCreatedBy)
                       .HasForeignKey(m => m.CreatedByID)
                       .WillCascadeOnDelete(false);

            HasOptional(r => r.UpdatedBy)
                    .WithMany(t => t.ChannelTypeUpdatedBy)
                    .HasForeignKey(m => m.UpdatedByID)
                    .WillCascadeOnDelete(false);
        }
    }
}
