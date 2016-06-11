using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class ServiceRepository : RepositoryBase<ServiceEntity>, IServiceRepository
    {
        public ServiceRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(ServiceEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IServiceRepository : IRepository<ServiceEntity>
    {

    }
    
}
