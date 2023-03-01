using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
                            Console.WriteLine(f);   
                    };
                    break;

                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination == filterValue)
                            FlightsFiltered.Add(f);
                            Console.WriteLine(f);
                    };
                    break;
            }
            return FlightsFiltered;
        }
        public void ShowFlightDetails(Plane plane)
        {
            /*M1:LINK: var query = from f in Flights where f.Plane == plane select new { f.FlightDate, f.Destination };
            return query.ToList().ForEach(f => { Console.WriteLine(f.Destination + "and" + f.FlightDate); });*/
            //M2.1:
            var details1 = Flights.Where(f=>f.Plane.Equals(plane)).Select(f=> (f.FlightDate, f.Destination ));
            //M2.2:
           // var details2 = plane.Flights.Select(f => (f.FlightDate, f.Destination));
            foreach (var v in details1)
                Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);

        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            /*M1:query
            var query = from f in Flights where (startDate - f.FlightDate).TotalDays < 7 select f;
            return query.Count();*/
            //M2
            //return Flights.Where(f => f.FlightDate <= startDate.AddDays(7)).Count();
            return Flights.Count(f => f.FlightDate <= startDate.AddDays(7));
        }

        public Double DurationAverage(string destination)
        {
            /*M1:Linq
            var query = from f in Flights where f.Destination == destination select f.EstimatedDuration;
            return query.Average();*/
            //M2:lambda
            return Flights.Where(f => f.Destination == destination).Select(f => f.EstimatedDuration).Average();

        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            /*M1:linq
            var flightsquery = from f in Flights orderby f.EstimatedDuration descending select f;
            foreach (Flight f in flightsquery)
            {
                Console.WriteLine(f.FlighId);
            }*/
            return Flights.OrderByDescending(f => f.EstimatedDuration);

        }
        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            /*M1:
            var query = from f in flight.Passengers.OfType<Traveller>() orderby f.BirthDate descending select f;
            return query.OfType<Traveller>().Take(3);*/
            //M2:
            return flight.Passengers.OfType<Traveller>().OrderByDescending(f => f.BirthDate).Take(3);
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;

            //  var reqLambda = Flights.GroupBy(f => f.Destination);

            foreach (var g in req)
            {
                Console.WriteLine("Destination: " + g.Key);
                foreach (var f in g)
                    Console.WriteLine("Décollage: " + f.FlightDate);

            }
            return req;
        }
    }
}