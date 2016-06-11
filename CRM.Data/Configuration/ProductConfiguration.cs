using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Configuration
{
    public class ProductConfiguration: EntityTypeConfiguration<ProductEntity>
    {
        public ProductConfiguration()
        {
            ToTable("Products");
            Property(g => g.SerialNumber).IsRequired().HasMaxLength(100);
            Property(g => g.Model).HasMaxLength(100);
            Property(g => g.WarrantyCode).HasMaxLength(100);
            Property(g => g.WarrantyDescription).HasMaxLength(250);

            Property(g => g.CustomerID).IsRequired();
            Property(g => g.ShippingCountryID).IsRequired();
            Property(g => g.CategoryID).IsRequired();
            Property(g => g.TypeID).IsRequired();
        }
    }
}
