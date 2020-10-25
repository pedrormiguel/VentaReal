using System;
using Microsoft.EntityFrameworkCore;
using VentaReal.API.Entities;

namespace VentaReal.API.Data
{
    public class VentaRealContext : DbContext
    {
        public VentaRealContext(DbContextOptions<VentaRealContext> options) :
        base(options) 
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Venta> Venta {get; set;}
        public DbSet<Cliente> Cliente { get; set;} 
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Concepto> Concepto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost,1433;Database=VentaReal;User Id=sa;Password=Pedrito256");
        }
    }
}
   