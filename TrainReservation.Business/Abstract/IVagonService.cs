using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Entities.Concrete;

namespace TrainReservation.Business.Abstract
{
    public interface IVagonService:IServiceCollection<Vagon>,IServiceFilter<Vagon>
    {
    }
}
