using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainReservation.API.Model;
using TrainReservation.Business.Abstract;
using TrainReservation.Business.Ninject;

namespace TrainReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        ITrainService trainService;
        IVagonService vagonService;

        Dictionary<string, int> availability;
        Dictionary<string, int> seats;
        bool state = true,finishState=false;

        public ReservationController()
        {
            trainService = InstanceFactory.GetInstance<ITrainService>();
            vagonService = InstanceFactory.GetInstance<IVagonService>();
        }

        [HttpPost]
        [Route("reservationRequest")]
        public IActionResult ReservationRequest(RequestModel model)
        {
            int passengers = model.RezervasyonYapilacakKisiSayisi;
            int r_passenger = 0;

            if (model.KisilerFarkliVagonlaraYerlestirilebilir)
            {
                availability = new Dictionary<string, int>();
                seats = new Dictionary<string, int>(); 
                availability = CalculateAvailabilityofWagons(model.Tren.Vagonlar);

                foreach (var item in availability)
                {
                    int value = item.Value;

                    if (value > 0)
                    {
                        if ((value - passengers) >= 0)
                        {
                            seats[item.Key] = passengers;
                            finishState = true;
                            break;
                        }
                        if (passengers>0)
                        {
                            if (passengers>value)
                            {
                                r_passenger = passengers - value;
                                seats[item.Key] = value;
                                passengers = r_passenger;
                            }
                            else
                            {
                                r_passenger = value - passengers;
                                seats[item.Key] = passengers;
                                passengers = r_passenger;
                            }
                        }
                        if (passengers == 0)
                        {
                            finishState = true;
                            break;
                        }
                        
                    }

                }

                if (finishState)
                {
                    List<ResidentialDetails> details = new List<ResidentialDetails>();

                    foreach (var item in seats)
                    {
                        details.Add(new ResidentialDetails
                        {
                            VagonName = item.Key,
                            NumberOfPassengers = item.Value
                        });
                    }

                    return Ok(new ResponseModel
                    {
                        RezervasyonYapilabilir = true,
                        YerlesimAyrinti = details
                    });
                }
                else
                {
                    return Ok(new ResponseModel
                    {
                        RezervasyonYapilabilir = false,
                        YerlesimAyrinti = (new List<ResidentialDetails>())
                    });
                }
            }
            else
            {
                availability = new Dictionary<string, int>();
                availability = CalculateAvailabilityofWagons(model.Tren.Vagonlar);
                string key = model.Tren.Vagonlar[0].Ad;

                if (availability[key] >= passengers)
                {
                    return Ok(new ResponseModel
                    {
                        RezervasyonYapilabilir = true,
                        YerlesimAyrinti = (new List<ResidentialDetails>
                        {
                            new ResidentialDetails{NumberOfPassengers = passengers,VagonName = key}
                        })
                    });
                }
                else
                {
                    return Ok(new ResponseModel
                    {
                        RezervasyonYapilabilir = false,
                        YerlesimAyrinti = (new List<ResidentialDetails>())
                    });
                }
            }
        }

        public bool CalculatePercent(int numberOfPassengers,int presence,int numberOfFullSeat)
        {
            double threshold = (presence * 70) / 100;
            int netAmount = numberOfPassengers + numberOfFullSeat;
            
            return netAmount <= threshold ? true : false;
        }

        public Dictionary<string,int> CalculateAvailabilityofWagons(List<VagonDto> model)
        {
            Dictionary<string, int> availability = new Dictionary<string, int>();
            int counter = 1;

            for (int i = 0; i < model.Count; i++)
            {
                availability.Add(model[i].Ad, 0);
                while (true)
                {
                    if (CalculatePercent(counter, model[i].Kapasite, model[i].DoluKoltukAdet))
                    {
                        availability[model[i].Ad] = counter;
                        counter++;
                        if (!CalculatePercent(counter, model[i].Kapasite, model[i].DoluKoltukAdet))
                        {
                            break;
                        }
                    }
                }
                counter = 1;
            }

            return availability;
        }

    }
}
