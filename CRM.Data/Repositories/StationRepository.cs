using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class StationRepository : RepositoryBase<StationEntity>, IStationRepository
    {
        public StationRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(StationEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IStationRepository : IRepository<StationEntity>
    {

    }
    
}
