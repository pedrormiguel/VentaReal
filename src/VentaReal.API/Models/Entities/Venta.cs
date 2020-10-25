using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace VentaReal.API.Entities
{
    public class Venta
    {
        [Key]
        public int IdVenta {get; set;}

        public DateTime fecha {get; set;}

        [ForeignKey("Cliente")]
        public int IdCliente  { get; set; }
        public Cliente Cliente { get; set;}

        public double total { get; set; }
    }
}