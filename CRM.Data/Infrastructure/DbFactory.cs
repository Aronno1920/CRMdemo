using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Infrastructure
{    
    public class DbFactory : Disposable, IDbFactory
    {
        CRMEntities dbContext;

        public CRMEntities Init()
        {
            return dbContext ?? (dbContext = new CRMEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
