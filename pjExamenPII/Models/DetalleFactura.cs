using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pjExamenPII.Models
{
    public class DetalleFactura
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int IdFactura { get; set; }
        [ForeignKey("IdFactura")]
        public Facturas? Facturas { get; set; }
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public Productos? Productos { get; set; }
        public int Cantididad { get; set; }
    }
}
