using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class ServiceTypeRepository : RepositoryBase<ServiceTypeEntity>, IServiceTypeRepository
    {
        public ServiceTypeRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(ServiceTypeEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IServiceTypeRepository : IRepository<ServiceTypeEntity>
    {

    }
    
}
