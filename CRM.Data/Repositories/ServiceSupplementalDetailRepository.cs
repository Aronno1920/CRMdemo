using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class ServiceSupplementalDetailRepository : RepositoryBase<ServiceSupplementalDetailEntity>, IServiceSupplementalDetailRepository
    {
        public ServiceSupplementalDetailRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(ServiceSupplementalDetailEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IServiceSupplementalDetailRepository : IRepository<ServiceSupplementalDetailEntity>
    {

    }
    
}
