using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Entities.Concrete;

namespace TrainReservation.DataAccess.Abstract
{
    public interface IVagonDal : IEntityRepository<Vagon>, IEntityFilter<Vagon>
    {

    }
}
