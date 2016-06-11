
using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using CRM.Data.Repositories;

namespace CRM.Service.Service
{
    // operations you want to expose
    //public interface ICRMService<T>: IRepository<T> where T : class
    //{
    //    IEnumerable<T> GetAll(string name = null);
    //}
    // operations you want to expose
    public interface ICustomerService
    {
        IQueryable<CustomerEntity> AllIncluding(params Expression<Func<CustomerEntity, object>>[] includeProperties);
        // Marks an entity as new
        void Add(CustomerEntity entity);
        // Marks an entity as modified
        void Update(CustomerEntity entity);
        // Get an entity by int id
        CustomerEntity GetById(int id);
        // Get an entity using delegate
        CustomerEntity Get(Expression<Func<CustomerEntity, bool>> where);
        // Gets all entities of type T
        IEnumerable<CustomerEntity> GetAll();
        // Gets entities using delegate
        IEnumerable<CustomerEntity> GetMany(Expression<Func<CustomerEntity, bool>> where);

        IEnumerable<CustomerEntity> SearchCustomer(string frequentFlyerId, string customerID, string fullName, string mobile, string phone, string email, string serviceCode, string productSerial, string interactionCode);
        void Save();

    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(ICustomerRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(CustomerEntity entity)
        {
            repository.Add(entity);
        }

        public IQueryable<CustomerEntity> AllIncluding(params Expression<Func<CustomerEntity, object>>[] includeProperties)
        {
            return repository.AllIncluding(includeProperties);
        }

        public CustomerEntity Get(Expression<Func<CustomerEntity, bool>> where)
        {
            return repository.Get(where);
        }

        public IEnumerable<CustomerEntity> GetAll()
        {
            return repository.GetAll();
        }

        public CustomerEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<CustomerEntity> GetMany(Expression<Func<CustomerEntity, bool>> where)
        {
            return repository.GetMany(where);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<CustomerEntity> SearchCustomer(string frequentFlyerId, string customerID, string fullName, string mobile, string phone, string email, string serviceCode, string productSerial, string interactionCode)
        {
            return repository.SearchCustomer(frequentFlyerId, customerID, fullName, mobile, phone, email, serviceCode, productSerial, interactionCode);
        }

        public void Update(CustomerEntity entity)
        {
            repository.Update(entity);
        }
    }
}
