using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Configuration
{
    public class InteractionConfiguration : EntityTypeConfiguration<InteractionEntity>
    {
        public InteractionConfiguration()
        {
            ToTable("Interactions");
            Property(g => g.Code).IsRequired().HasMaxLength(100);
            Property(g => g.Comments).HasMaxLength(250);

            Property(g => g.ServiceID).IsRequired();
            Property(g => g.ChannelTypeID).IsRequired();
            Property(g => g.CurrentOutcomeCodeID).IsRequired();
        }
    }
}
