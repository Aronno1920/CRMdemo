using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class ProductTypeRepository : RepositoryBase<ProductTypeEntity>, IProductTypeRepository
    {
        public ProductTypeRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(ProductTypeEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IProductTypeRepository : IRepository<ProductTypeEntity>
    {

    }
    
}
