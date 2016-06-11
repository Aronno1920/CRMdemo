using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class LanguageRepository : RepositoryBase<LanguageEntity>, ILanguageRepository
    {
        public LanguageRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(LanguageEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface ILanguageRepository : IRepository<LanguageEntity>
    {

    }
    
}
