
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
    public class ChannelTypeService : IRepository<ChannelTypeEntity>
    {
        private readonly IRepository<ChannelTypeEntity> repository;
        private readonly IUnitOfWork unitOfWork;

        public ChannelTypeService(IRepository<ChannelTypeEntity> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(ChannelTypeEntity entity)
        {
            repository.Add(entity);
        }

        public void Delete(Expression<Func<ChannelTypeEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(ChannelTypeEntity entity)
        {
            repository.Delete(entity); 
        }

        public ChannelTypeEntity Get(Expression<Func<ChannelTypeEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChannelTypeEntity> GetAll()
        {
            return repository.GetAll();
        }

        public ChannelTypeEntity GetById(int id)
        {
            var channelType = repository.GetById(id);
            return channelType;
        }

        public IEnumerable<ChannelTypeEntity> GetMany(Expression<Func<ChannelTypeEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(ChannelTypeEntity entity)
        {
            repository.Update(entity);
        }
        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}
