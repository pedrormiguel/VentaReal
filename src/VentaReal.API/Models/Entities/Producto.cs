using System.ComponentModel.DataAnnotations;

namespace VentaReal.API.Entities
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public double PrecioUnitario { get; set; }
        public double Costo { get; set; }
    }
}