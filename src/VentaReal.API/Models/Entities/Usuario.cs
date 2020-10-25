using System.ComponentModel.DataAnnotations;

namespace VentaReal.API.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string password { get; set; }          
    }
}