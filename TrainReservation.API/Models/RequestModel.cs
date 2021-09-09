using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainReservation.Entities.Concrete;

namespace TrainReservation.API.Model
{
    public class RequestModel
    {
        public TrainDto Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }

    }
}
