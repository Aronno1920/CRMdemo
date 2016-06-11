using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class PriorityRepository : RepositoryBase<PriorityEntity>, IPriorityRepository
    {
        public PriorityRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(PriorityEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IPriorityRepository : IRepository<PriorityEntity>
    {

    }
    
}
