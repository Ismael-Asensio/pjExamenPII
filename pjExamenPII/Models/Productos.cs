using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pjExamenPII.Models
{
    public class Productos
    {
        [Key]
        [Required]
        public int id { get; set; }

        [StringLength(60)]
        public string Nombres { get; set; }

        [Precision(18, 2)]
        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int IdProducto { get; set; }
    }
}
