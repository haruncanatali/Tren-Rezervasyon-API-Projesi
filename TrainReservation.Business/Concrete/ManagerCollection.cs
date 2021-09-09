using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TrainReservation.Business.Abstract;
using TrainReservation.DataAccess.Abstract;
using TrainReservation.Entities.Abstract;

namespace TrainReservation.Business.Concrete
{
    public class ManagerCollection<TEntity,TDal> : IServiceCollection<TEntity>, IServiceFilter<TEntity> where TEntity : class, IEntity, new() where TDal:IEntityRepository<TEntity>,IEntityFilter<TEntity>
    {
        TDal dal;
        public ManagerCollection(TDal x)
        {
            this.dal = x;
        }

        public void Add(TEntity entity)
        {
            dal.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            dal.Delete(entity);
        }

        public List<TEntity> GetEntities(Expression<Func<TEntity, bool>> filter = null)
        {
            return dal.GetEntities(filter);
        }

        public TEntity GetEntity(Expression<Func<TEntity, bool>> filter)
        {
            return dal.GetEntity(filter);
        }

        public void Update(TEntity entity)
        {
            dal.Update(entity);
        }
    }
}
