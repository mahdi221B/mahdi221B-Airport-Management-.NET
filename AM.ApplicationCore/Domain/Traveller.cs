using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }

        //héritage : override
        public override void PassengerType()
        {
            Console.WriteLine("In this flight i'am a traveller");
        }
    }
}
