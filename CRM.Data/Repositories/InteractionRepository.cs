using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class InteractionRepository : RepositoryBase<InteractionEntity>, IInteractionRepository
    {
        public InteractionRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(InteractionEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IInteractionRepository : IRepository<InteractionEntity>
    {

    }
    
}
