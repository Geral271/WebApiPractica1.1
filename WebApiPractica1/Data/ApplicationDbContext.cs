using Microsoft.EntityFrameworkCore;
using WebApiPractica1.Entidades;

namespace WebApiPractica1.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Turista> Turistas { get; set; }
        public DbSet<ContratoSucursal> ContratoSucursalses { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<ReservaVuelo> ReservaVuelos { get; set; }
        public DbSet<ReservaHotel> ReservaHoteles { get; set; }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<ContratoSucursal> ContratoSucursales { get; set; }

    }
}
