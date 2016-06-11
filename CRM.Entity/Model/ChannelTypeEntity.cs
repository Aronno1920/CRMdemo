using CRM.Entity.Authentication;
using System;
using System.Collections.Generic;

namespace  CRM.Entity.Model
{   
    public class ChannelTypeEntity:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<InteractionEntity> Interactions { get; set; }
    }
}