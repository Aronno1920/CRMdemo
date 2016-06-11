using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class ServiceCenterRepository : RepositoryBase<ServiceCenterEntity>, IServiceCenterRepository
    {
        public ServiceCenterRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(ServiceCenterEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IServiceCenterRepository : IRepository<ServiceCenterEntity>
    {

    }
    
}
