using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.DataAccess.Abstract;
using TrainReservation.Entities.Abstract;

namespace TrainReservation.DataAccess.Concrete
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        TrainReservationAppContext context;
        public EntityRepository(TrainReservationAppContext context_)
        {
            this.context = context_;
        }

        public void Add(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
