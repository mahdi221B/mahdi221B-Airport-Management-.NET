﻿using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
    //Not internal
{
    // public class AMContext ; class simple on doit ajouter class de configuration "DbContext"
    public class AMContext : DbContext
    {
        //Intermédiare entre l'entité et table => "DbSet"
        //public DbSet<Entity> Table{ get; set; }
        public DbSet<Flight> Flights{ get; set; }
        public DbSet<Plane> Planes{ get; set; }
        public DbSet<Traveller> Travellers{ get; set; }
        public DbSet<Staff> Staffs{ get; set; }
        public DbSet<Passenger> Passengers{ get; set; }

        //ovveride on
        //chaine de cnx
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
          
            Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        //genere Base a traver deux commande in : view -> other -> Package Manager console
        //Install 2 packages afin d'utiliser cette class de configuration DbContext et UseSqlServer
        //.Design schema de Base dans Console
        //.Tools in Infra

        //Appliquer Fluent API 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //Configuration complexe Fluent API
            modelBuilder.Entity<Passenger>()
                .OwnsOne(p => p.FullName, full =>
                {
                    full.Property(p => p.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
                    full.Property(p => p.LastName).HasColumnName("PassLastName").IsRequired();
                });
        }
        //override con
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
                                          //<Type> (name)
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
        }
    } 
}