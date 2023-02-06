using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmployementDateTime { get; set; }
        public Double Salary { get; set; }
        public string ? Function { get; set; }

        //héritage : override
        public override void PassengerType()
        {
            Console.WriteLine("In this flight i'am a one of the Staff members");
        }
    }
    
}