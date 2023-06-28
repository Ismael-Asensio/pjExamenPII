using Microsoft.EntityFrameworkCore;
using pjExamenPII.Models;

namespace pjExamenPII.Data
{
    public class FacturaContext : DbContext
    {
        public FacturaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet <Productos> Productos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet <DetalleFactura> DetalleFacturas { get; set; }
        public DbSet <Facturas> Facturas { get; set; }
    }
}
