using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Business.Abstract;
using TrainReservation.Business.Concrete;
using TrainReservation.DataAccess.Abstract;
using TrainReservation.DataAccess.Concrete;

namespace TrainReservation.Business.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITrainService>().To<TrainManager>().InTransientScope();
            Bind<ITrainDal>().To<TrainDal>().InTransientScope();

            Bind<IVagonService>().To<VagonManager>().InTransientScope();
            Bind<IVagonDal>().To<VagonDal>().InTransientScope();
        }
    }
}
