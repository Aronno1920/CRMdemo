using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class CustomerConfiguration : EntityTypeConfiguration<CustomerEntity>
    {
        public CustomerConfiguration()
        {
            ToTable("Customers");
            Property(g => g.Code).IsRequired().HasMaxLength(50);
            Property(g => g.FrequentFlyierCode).IsRequired().HasMaxLength(50);
            Property(g => g.ProjectName).HasMaxLength(100);
            Property(g => g.DealerName).HasMaxLength(100);
            Property(g => g.FullName).IsRequired().HasMaxLength(100);
            Property(g => g.MobileNumber).IsRequired().HasMaxLength(20);
            Property(g => g.Phone).HasMaxLength(20);
            Property(g => g.OtherEmail).HasMaxLength(100);


            Property(g => g.ContactTypeID).IsRequired();
            Property(g => g.TitleID).IsRequired();
            Property(g => g.LanguageID).IsRequired();
            //Property(g => g.CountryID).IsRequired();
        }
    }
}
