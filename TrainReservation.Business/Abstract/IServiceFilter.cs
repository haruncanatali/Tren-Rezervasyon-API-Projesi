using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TrainReservation.Entities.Abstract;

namespace TrainReservation.Business.Abstract
{
    public interface IServiceFilter<TEntity> where TEntity:class,IEntity,new()
    {
        TEntity GetEntity(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetEntities(Expression<Func<TEntity, bool>> filter = null);
    }
}
