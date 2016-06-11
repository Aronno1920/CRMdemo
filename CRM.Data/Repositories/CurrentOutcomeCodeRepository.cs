using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class CurrentOutcomeCodeRepository : RepositoryBase<CurrentOutcomeCodeEntity>, ICurrentOutcomeCodeRepository
    {
        public CurrentOutcomeCodeRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(CurrentOutcomeCodeEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface ICurrentOutcomeCodeRepository : IRepository<CurrentOutcomeCodeEntity>
    {

    }
    
}
