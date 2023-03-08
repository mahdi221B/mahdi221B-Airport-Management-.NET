using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        //Proprieté de base
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string ? Departure { get; set; }
        public string ? Destination { get; set; }
        public String AireLineLogo { get; set; }
        //Proprieté de navigation
            //deux méthode
            //M1
            [ForeignKey("Plane")]
            public int planeFK { get; set; }
            //M2
            [ForeignKey("planeFK")]
            public Plane Plane { get; set; }
        public ICollection<Passenger> ? Passengers { get; set; }
    }
}
