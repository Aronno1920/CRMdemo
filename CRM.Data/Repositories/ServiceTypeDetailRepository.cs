using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class ServiceTypeDetailRepository : RepositoryBase<ServiceTypeDetailEntity>, IServiceTypeDetailRepository
    {
        public ServiceTypeDetailRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(ServiceTypeDetailEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IServiceTypeDetailRepository : IRepository<ServiceTypeDetailEntity>
    {

    }
    
}
