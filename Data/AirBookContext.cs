namespace AirBook.Data
{
    using Microsoft.EntityFrameworkCore;
    using AirBook.Data;
    using global::AirBook.Models;

    namespace AirBook.Data
    {
        public class AirBookContext : DbContext
        {
            public AirBookContext(DbContextOptions<AirBookContext> options) : base(options) { }

            public DbSet<Pasajero> Pasajeros { get; set; }
            public DbSet<Vuelo> Vuelos { get; set; }
            public DbSet<Reserva> Reservas { get; set; }
            public DbSet<Aerolinea> Aerolineas { get; set; }
            public DbSet<Itinerario> Itinerarios { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Aerolinea>().HasKey(a => a.IdAerolinea);
                modelBuilder.Entity<Pasajero>().HasKey(p => p.IdPasajero);
                modelBuilder.Entity<Vuelo>().HasKey(v => v.IdVuelo);
                modelBuilder.Entity<Reserva>().HasKey(r => r.IdReserva);
                modelBuilder.Entity<Itinerario>().HasKey(i => i.IdItinerario);

                // Especificar el tipo de columna y la precisión para el campo Precio
                modelBuilder.Entity<Vuelo>()
                    .Property(v => v.Precio)
                    .HasColumnType("decimal(18,2)");
            }
        }
    }
}
