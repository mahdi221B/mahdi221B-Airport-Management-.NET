﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //Proprieté de base
        //Clé primaire declaré directement {ID,Id,PassengerId} or CIN and we have to add annotation which is [Key]
        // public int Id { get; set; }
        [Key,StringLength(7)]
        public string PassportNumber { get; set; }
        [MinLength(3,ErrorMessage ="invalide"),MaxLength(25, ErrorMessage = "invalide")]
       
        [DataType(DataType.Date)]
        [DisplayName("Date of birth")]
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public int TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAdress { get; set; }
        public FullName? FullName { get; set; }

        //Proprieté de navigation
        public ICollection<Flight> ? Flights { get; set; }
        //QuickActions + Generate Override
        public override string? ToString()
        {
            return "Passenger passport number "+ PassportNumber + "Full Name"+ FullName.ToString;
            //Est l'affichage de la méthode mére => return base.ToString();
        }

        //Polymorphisme
        //M1
        public bool checkProfile(string FirstName, string LastName)
        {
            return (this.FullName.FirstName.Equals(FirstName) && this.FullName.LastName.Equals(LastName));
        }
            //M2
        public bool checkProfile(string FirstName, string LastName, string Email)
        {
            return (this.FullName.FirstName.Equals(FirstName) && this.FullName.LastName.Equals(LastName) && EmailAdress.Equals(Email));
        }
            //M3
        public bool login(string FirstName, string LastName, string Email = null)
        {
            //if (Email!=null)
            //    return checkProfile(FirstName, LastName, Email);
            //return checkProfile(FirstName, LastName);

            return Email!=null ? checkProfile(FirstName,LastName,Email) : checkProfile(FirstName,LastName);

            //à verfier
            //return (FirstName.Equals(FirstName) && LastName.Equals(LastName) && Email.Equals(Email))
            //    || (FirstName.Equals(FirstName) && LastName.Equals(LastName));
        }


        //abstract : seulement dans les class abstraite juste signiature sans implémentation 
        //virtual : On peut ajouter de l'implémentation => on peut l'hériter
        public virtual void PassengerType()
        {
            //cwl+ double tab
           Console.WriteLine("I am passenger");
        }

    }
}
