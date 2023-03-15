using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    internal class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //Configuration de *-* en changeant le nom de la Table associative
            //1p is not the same 2p
            builder.HasMany(p => p.Passengers)
                .WithMany(p => p.Flights)
                .UsingEntity(t => t.ToTable("vole"));
            //Config de 1-*
            builder.HasOne(p => p.Plane)
                .WithMany(p => p.Flights)
               // .HasForeignKey(p => p.PlaneFK); // [ForeignKey("planeFK")]
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
