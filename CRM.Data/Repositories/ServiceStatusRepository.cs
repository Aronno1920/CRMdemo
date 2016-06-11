using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class ServiceStatusRepository : RepositoryBase<ServiceStatusEntity>, IServiceStatusRepository
    {
        public ServiceStatusRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(ServiceStatusEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IServiceStatusRepository : IRepository<ServiceStatusEntity>
    {

    }
    
}
