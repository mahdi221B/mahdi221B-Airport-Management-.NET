using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        public IList<DateTime> GetFlightDate(string Destination);
        public void ShowFlightDetails(Plane plane);
        public int ProgrammedFlightNumber(DateTime startDate);
        public Double DurationAverage(string destination);
        public IEnumerable<Flight> OrderedDurationFlights();
        //public void SeniorTravellers(Flight flight);
    }
}
