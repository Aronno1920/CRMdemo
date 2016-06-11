using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class ProductTypeConfiguration : EntityTypeConfiguration<ProductTypeEntity>
    {
        public ProductTypeConfiguration()
        {
            ToTable("ProductTypes");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}
