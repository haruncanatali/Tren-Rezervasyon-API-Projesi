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
    public class VagonDal : EntityRepository<Vagon>, IVagonDal
    {
        TrainReservationAppContext context;
        public VagonDal(TrainReservationAppContext context_) : base(context_)
        {
            context = context_;
        }

        public List<Vagon> GetEntities(Expression<Func<Vagon, bool>> filter = null)
        {
            return filter == null ? context.Tbl_Vagon.ToList() : context.Tbl_Vagon.Where(filter).ToList();
        }

        public Vagon GetEntity(Expression<Func<Vagon, bool>> filter) 
        {
            return context.Tbl_Vagon.SingleOrDefault(filter);
        }
    }
}
