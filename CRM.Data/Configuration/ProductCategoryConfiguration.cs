using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategoryEntity>
    {
        public ProductCategoryConfiguration()
        {
            ToTable("ProductCategories");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}
