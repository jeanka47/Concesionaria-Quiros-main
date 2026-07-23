
using ConcesionariaQuiros.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConcesionariaQuiros.Data
{
    public class ConcesionariaContext : DbContext
    {
        public ConcesionariaContext(DbContextOptions<ConcesionariaContext> options)
            : base(options)
        {
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Concesionario> Concesionarios { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Mecanico> Mecanicos { get; set; }
        public DbSet<Refaccion> Refacciones { get; set; }
        public DbSet<Reparacion> Reparaciones { get; set; }
        public DbSet<Revision> Revisiones { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public  DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }




    }
}
