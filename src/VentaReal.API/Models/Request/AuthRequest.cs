using System.ComponentModel.DataAnnotations;

namespace VentaReal.API.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string Correo { get; set; }
        
        [Required]
        public string Password { get; set; }

    }
}