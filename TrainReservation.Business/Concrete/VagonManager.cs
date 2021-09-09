using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Business.Abstract;
using TrainReservation.DataAccess.Abstract;
using TrainReservation.Entities.Concrete;

namespace TrainReservation.Business.Concrete
{
    public class VagonManager : ManagerCollection<Vagon, IVagonDal>, IVagonService
    {
        public VagonManager(IVagonDal x) : base(x)
        {
        }
    }
}
