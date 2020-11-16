using System.Runtime.CompilerServices;
using System;
using Microsoft.EntityFrameworkCore;
using VentaReal.API.Entities;
using VentaReal.API.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace VentaReal.API.Data
{
    public class VentaRealContext : DbContext
    {
        private IConfiguration _configuration ;
        
        public VentaRealContext(DbContextOptions<VentaRealContext> options, IConfiguration configuration) :
        base(options) 
        {
            _configuration = configuration;
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Venta> Venta {get; set;}
        public DbSet<Cliente> Cliente { get; set;} 
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Concepto> Concepto { get; set; }
        public DbSet<Usuario> Usuario { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer( _configuration.GetSection("ConnectionStrings").Value );
        }
    }
}
   