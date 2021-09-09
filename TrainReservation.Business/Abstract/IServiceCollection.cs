using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Entities.Abstract;

namespace TrainReservation.Business.Abstract
{
    public interface IServiceCollection<TEntity> where TEntity:class,IEntity,new()
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
