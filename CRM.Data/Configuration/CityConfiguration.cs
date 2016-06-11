using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class CityConfiguration : EntityTypeConfiguration<CityEntity>
    {
        public CityConfiguration()
        {
            ToTable("Cities");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            //Property(g => g.CityTypeID).IsRequired();

            HasRequired(m => m.CityType)
                        .WithMany(t => t.Cities)
                        .HasForeignKey(m => m.CityTypeID)
                        .WillCascadeOnDelete(false);

            HasOptional(m => m.CreatedBy)
                        .WithMany(t => t.CityCreatedBy)
                        .HasForeignKey(m => m.CreatedByID)
                        .WillCascadeOnDelete(false);

            HasOptional(r => r.UpdatedBy)
                    .WithMany(t => t.CityUpdatedBy)
                    .HasForeignKey(m => m.UpdatedByID)
                    .WillCascadeOnDelete(false);
        }
    }
}
