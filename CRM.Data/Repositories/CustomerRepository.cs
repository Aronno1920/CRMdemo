using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(CustomerEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
        public IEnumerable<CustomerEntity> SearchCustomer(string frequentFlyerId, string customerID, string fullName, string mobile, string phone, string email, string serviceCode, string productSerial, string interactionCode)
        {
            var customers = from c in this.DbContext.Customers
                            join s in this.DbContext.Services on c.ID equals s.CustomerID
                            join p in this.DbContext.Products on c.ID equals p.CustomerID
                            join i in this.DbContext.Interactions on s.ID equals i.ServiceID
                            where c.Code.Contains(customerID) 
                                    && c.FrequentFlyierCode.Contains(frequentFlyerId)
                                    && c.FullName.Contains(fullName)
                                    && c.MobileNumber.Contains(mobile)
                                    && c.Phone.Contains(phone)
                                    && c.Email.Contains(email)
                                    && s.Code.Contains(serviceCode)
                                    && p.SerialNumber.Contains(productSerial)
                                    && i.Code.Contains(interactionCode)
                            select c;
            return customers.ToList();
        }

    }

    public interface ICustomerRepository : IRepository<CustomerEntity>
    {
        IEnumerable<CustomerEntity> SearchCustomer(string frequentFlyerId, string customerID, string fullName, string mobile, string phone, string email, string serviceCode, string productSerial, string interactionCode);
    }
    
}
