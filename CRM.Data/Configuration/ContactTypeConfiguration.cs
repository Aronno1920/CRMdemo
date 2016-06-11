using CRM.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace CRM.Data.Configuration
{
    public class ContactTypeConfiguration : EntityTypeConfiguration<ContactTypeEntity>
    {
        public ContactTypeConfiguration()
        {
            ToTable("ContactTypes");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}
