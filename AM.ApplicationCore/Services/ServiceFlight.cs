using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights = new List<Flight>();

        public IList<DateTime> GetFlightDate(string Destination)
        {
            /*M1:Avec ForEach
            List<DateTime> FlightsDate = new List<DateTime>();
            foreach (Flight f in Flights)
            {
                if (f.Destination == Destination)
                    FlightsDate.Add(f.FlightDate);
            }*/
            var query = from A in Flights where A.Destination == Destination select A.FlightDate;
            //M1: return (IList<DateTime>)query;
            return query.ToList();

        }

        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> FlightsFiltered = new List<Flight>();
            switch (filterType)
            {
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate.Equals(filterValue))
                            FlightsFiltered.Add(f);
                    };
                    break;

                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination == filterValue)
                            FlightsFiltered.Add(f);
                    };
                    break;
            }
            return FlightsFiltered;
        }

        public void ShowFlightDetails(Plane plane)
        {
            var query = from f in Flights where f.Plane == plane select new { f.FlightDate, f.Destination };
            query.ToList().ForEach(f => { Console.WriteLine(f.Destination+"and"+f.FlightDate); });
        }
    }
}
