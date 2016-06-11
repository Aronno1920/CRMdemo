using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class StationCategoryRepository : RepositoryBase<StationCategoryEntity>, IStationCategoryRepository
    {
        public StationCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(StationCategoryEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IStationCategoryRepository : IRepository<StationCategoryEntity>
    {

    }
    
}
