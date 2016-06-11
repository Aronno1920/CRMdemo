using CRM.Entity.Authentication;
using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class CityTypeConfiguration : EntityTypeConfiguration<CityTypeEntity>
    {
        public CityTypeConfiguration()
        {
            ToTable("CityTypes");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            HasOptional(m => m.CreatedBy)
                       .WithMany(t => t.CityTypesCreatedBy)
                       .HasForeignKey(m => m.CreatedByID)
                       .WillCascadeOnDelete(false);

            HasOptional(r => r.UpdatedBy)
                    .WithMany(t => t.CityTypesUpdatedBy)
                    .HasForeignKey(m => m.UpdatedByID)
                    .WillCascadeOnDelete(false);
        }
    }
}
