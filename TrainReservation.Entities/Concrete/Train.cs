using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Entities.Abstract;

namespace TrainReservation.Entities.Concrete
{
    public class Train:IEntity
    {
        public Train()
        {
            Vagons = new List<Vagon>();
        }
        public int Id { get; set; }
        public string TrainName { get; set; }

        public List<Vagon> Vagons { get; set; }
    }
}
