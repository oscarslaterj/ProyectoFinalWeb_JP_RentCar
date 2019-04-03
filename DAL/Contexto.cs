using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Rentas> Renta { get; set; }
        public DbSet<RentasDetalles> Rentadetalle { get; set; }

        public Contexto() : base("Constr") { }
    }
}