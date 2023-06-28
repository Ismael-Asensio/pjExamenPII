using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pjExamenPII.Models.Dto
{
    public class ClientesDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [StringLength(60)]
        public string Nombre { get; set; }
        [StringLength(60)]
        public string Apellido { get; set; }
        [StringLength (255)]
        public string Direccion { get; set; }
        public int IdCliente{ get; set; }
    }
}
