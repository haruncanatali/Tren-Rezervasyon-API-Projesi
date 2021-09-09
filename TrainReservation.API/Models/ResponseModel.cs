using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainReservation.API.Model
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            YerlesimAyrinti = new List<ResidentialDetails>();
        }

        public bool RezervasyonYapilabilir { get; set; }
        public List<ResidentialDetails> YerlesimAyrinti { get; set; }
    }

}
