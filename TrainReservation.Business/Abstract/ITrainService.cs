using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Entities.Concrete;

namespace TrainReservation.Business.Abstract
{
    public interface ITrainService:IServiceCollection<Train>,IServiceFilter<Train>
    {
    }
}
