
using CRM.Data.Infrastructure;
using CRM.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CRM.Service.Service
{
    // operations you want to expose
    //public interface ICRMService<T>: IRepository<T> where T : class
    //{
    //    IEnumerable<T> GetAll(string name = null);
    //}
    // operations you want to expose
    public interface ICRMService<T> : IRepository<T> where T : class
    {
        // IEnumerable<T> GetAll(string name = null);
        void Save();
        void Active(T entity);

    }

    public class CRMService<R> : ICRMService<R> where R:class
    {
        private readonly IRepository<R> repository;
        private readonly IUnitOfWork unitOfWork;

        public CRMService(IRepository<R> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Active(R entity)
        {
            repository.Update(entity);
        }

        public void Add(R entity)
        {
            repository.Add(entity);
        }

        public IQueryable<R> AllIncluding(params Expression<Func<R, object>>[] includeProperties)
        {
            return repository.AllIncluding(includeProperties);
        }

        public void Delete(Expression<Func<R, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(R entity)
        {
            repository.Delete(entity);
        }

        public R Get(Expression<Func<R, bool>> where)
        {
            return repository.Get(where);
        }

        public IEnumerable<R> GetAll()
        {
            return repository.GetAll();
        }

        #region ICategoryService Members

        public IEnumerable<R> GetAll(string name = null)
        {
            return repository.GetAll();

        }
        
        public R GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<R> GetMany(Expression<Func<R, bool>> where)
        {
            return repository.GetMany(where);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(R entity)
        {
            repository.Update(entity);
        }

        #endregion
    }
}
