using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class TitleRepository : RepositoryBase<TitleEntity>, ITitleRepository
    {
        public TitleRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(TitleEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface ITitleRepository : IRepository<TitleEntity>
    {

    }
    
}
