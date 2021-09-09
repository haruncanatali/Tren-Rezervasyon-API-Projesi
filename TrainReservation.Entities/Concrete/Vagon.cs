using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Entities.Abstract;

namespace TrainReservation.Entities.Concrete
{
    public class Vagon:IEntity
    {
        public int Id { get; set; }
        public string VagonName { get; set; }
        public int Capacity { get; set; }
        public int NumberOfFullSeat { get; set; }

        public int TrainId { get; set; }

        public virtual Train Train { get; set; }
    }
}
