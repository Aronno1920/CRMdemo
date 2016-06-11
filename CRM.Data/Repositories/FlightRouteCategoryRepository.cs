using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class FlightRouteCategoryRepository : RepositoryBase<FlightRouteCategoryEntity>, IFlightRouteCategoryRepository
    {
        public FlightRouteCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(FlightRouteCategoryEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IFlightRouteCategoryRepository : IRepository<FlightRouteCategoryEntity>
    {

    }
    
}
