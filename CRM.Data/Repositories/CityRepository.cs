using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class CityRepository : RepositoryBase<CityEntity>, ICityRepository
    {
        public CityRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(CityEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface ICityRepository : IRepository<CityEntity>
    {

    }
    
}
