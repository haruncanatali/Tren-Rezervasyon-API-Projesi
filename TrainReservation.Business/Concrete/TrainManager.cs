using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Business.Abstract;
using TrainReservation.DataAccess.Abstract;
using TrainReservation.Entities.Concrete;

namespace TrainReservation.Business.Concrete
{
    public class TrainManager : ManagerCollection<Train, ITrainDal>, ITrainService
    {
        public TrainManager(ITrainDal x) : base(x)
        {
        }
    }
}
