using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class ContactTypeRepository : RepositoryBase<ContactTypeEntity>, IContactTypeRepository
    {
        public ContactTypeRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(ContactTypeEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IContactTypeRepository : IRepository<ContactTypeEntity>
    {

    }
    
}
