using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentaReal.API.Entities
{
  [Table(name:"Cliente")] 
    public class Cliente 
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        public string Name { get; set; }
    }
}