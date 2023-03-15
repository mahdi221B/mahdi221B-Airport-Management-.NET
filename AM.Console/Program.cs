// See https://aka.ms/new-console-template for more information
// Adding proejct reefrence BD+ add + Project Referenece aprés Light+ Quick actions + Add the using
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
/*Plane p1 = new Plane();
//PN va pas utiliser nii set ni get => directement p1.name_attribute
p1.Capacity = 1222;
p1.PlaneId = 1;
p1.ManufactureDate = DateTime.Now;
p1.PlaneType = PlaneType.Boing;
Console.WriteLine("First Object"+p1.ToString);
//En utilisant constructeur paramaetré
Plane p2 = new Plane(2,200,DateTime.Now, PlaneType.Airbus);
Console.WriteLine("Seond Object!" + p2.ToString);
//En utilisant constructeur a 2 paramaetre
Plane p3 = new Plane(3, 300);
Console.WriteLine("Hello, World!" + p3.ToString);*/
//enutilisant l'initialiseur d'objet
Plane p4 = new Plane
{
    PlaneId = 4,
    Capacity = 22,
};
//enutilisant l'initialiseur d'objet p2
Flight f1 = new Flight
{
    Departure = "s1"
};
Flight f2 = new Flight
{
    Departure = "s2"
};
Plane p5 = new Plane
{
    PlaneId = 4,
    Capacity = 22,
    Flights = new List<Flight>(){
        f1,f2,
    }
};

Passenger p1 = new Passenger
{
    FullName = new FullName { FirstName = "Mahdi", LastName = "Dridi" },
    EmailAdress = "mahdi.dridi@esprit.tn"
};
p1.PassengerType();
Console.WriteLine(p1.login("Mahdi", "Dridi"));
Console.WriteLine(p1.login("Mashdi", "Dsridi", "mjjahdi.dridi@esprit.tn"));
Console.WriteLine(p1.login("Mahdi", "Dridi"));
Console.WriteLine(p1.login("Yassin", "Dridi"));

Traveller T1 = new Traveller();
T1.PassengerType();
Passenger S1 = new Staff();
S1.PassengerType();

ServiceFlight sf = new ServiceFlight();
//JmA
DateTime startDate = new DateTime(01 / 02 / 2023);
Console.WriteLine(sf.ProgrammedFlightNumber(startDate));
sf.Flights = TestData.listFlights;
sf.ShowFlightDetails(TestData.BoingPlane);