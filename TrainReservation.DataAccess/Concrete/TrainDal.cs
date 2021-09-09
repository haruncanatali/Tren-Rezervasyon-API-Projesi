using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TrainReservation.DataAccess.Abstract;
using TrainReservation.Entities.Concrete;

namespace TrainReservation.DataAccess.Concrete
{
    public class TrainDal : EntityRepository<Train>,ITrainDal
    {
        TrainReservationAppContext context;
        public TrainDal(TrainReservationAppContext x):base(x)
        {
            this.context = x;
        }

        public List<Train> GetEntities(Expression<Func<Train, bool>> filter = null)
        {
            return filter == null ? context.Tbl_Train.Include(c => c.Vagons).ToList() : context.Tbl_Train.Where(filter).Include(c => c.Vagons).Where(filter).ToList();
        }

        public Train GetEntity(Expression<Func<Train, bool>> filter)
        {
            return context.Tbl_Train.Include(c => c.Vagons).SingleOrDefault(filter);
        }
    }
}
