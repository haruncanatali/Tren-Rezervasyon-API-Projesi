using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Entities.Abstract;

namespace TrainReservation.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity:class,IEntity,new()
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
