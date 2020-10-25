using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VentaReal.API.Entities
{
    public class Concepto
    {
        [Key]
        public int IdConcepto { get; set; }

        [ForeignKey("Venta")]
        public int IdVenta  { get; set; }
        public Venta Venta { get; set; }

        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }
    }
}