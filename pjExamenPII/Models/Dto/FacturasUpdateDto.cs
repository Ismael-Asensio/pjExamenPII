using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pjExamenPII.Models.Dto
{
    public class FacturasUpdateDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Clientes? Clientes { get; set; }
        public int IdFactura { get; set; }
    }
}
