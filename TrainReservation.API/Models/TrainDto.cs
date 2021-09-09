using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainReservation.API.Model
{
    public class TrainDto
    {
        public TrainDto()
        {
            Vagonlar = new List<VagonDto>();
        }

        public string Ad { get; set; }

        public virtual List<VagonDto> Vagonlar { get; set; }
    }
}
