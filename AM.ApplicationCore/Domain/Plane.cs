using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{//accessible que dans projet ApplicationCore
    //Par défaut internal
    public class Plane
    {
        //Constructeur paramaeté selecionner les attributs + quock actions + generate constructor
        //RQ : pour eviter les erreurs on doit declare constructeur vide
        public Plane(int planeId, int capacity, DateTime manufactureDate, PlaneType planeType)
        {
            PlaneId = planeId;
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneType = planeType;
        }
        public Plane(int planeId, int capacity)
        {
            PlaneId = planeId;
            Capacity = capacity;
        }
        public Plane()
        {
        }

        //Proprieté de base
        #region exemple
        //private string name;

        //public string GetName()
        //{return name;}
        //public void SetName ( string name)
        //{this.name = name;}
        ////prop + deux TAB :  par défaut int
        ////On n'utilise pas d'attribut : get+ set on utilise des properties
        ////properties encapsule get et set et attribut
        ////1ere : light version 
        //    //name propertie toujours en majuscule 
        //        //Exemple: Name { name attribut ; GetName ; SetName }
        //public int MyProperty { get; set; }

        ////2 éme ecriture : propfull + 2 TABA => full version :  qui donne la main pour faire des modification et ajouter un comprtement
        //private int number;

        //public int Number
        //{
        //    get { return number; }
        //    set { number = value; }
        //}

        ////3éme ecriture :  secure version
        //public int MyProperty { get; private set; }
        #endregion
        public int PlaneId { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType PlaneType { get; set; }

        //Proprieté de navigation
        public ICollection<Flight> ? Flights { get; set;} 

    }
}
