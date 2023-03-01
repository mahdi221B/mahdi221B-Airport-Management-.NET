using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    internal class AMContext : DbContext
    {
        //Intermédiare entre l'entité et table
        public DbSet<Flight> Flights{ get; set; }
        public DbSet<Plane> Planes{ get; set; }
        public DbSet<Traveller> Travellers{ get; set; }
        public DbSet<Staff> Staffs{ get; set; }
        public DbSet<Passenger> Passengers{ get; set; }

        //ovveride on
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        //genere Base a traver deux commande in : view -> other -> Package Manager console
            //Install 2 packages
            //.Design schema de Base dans Console
            //.Tools dans l'infra
    }
}