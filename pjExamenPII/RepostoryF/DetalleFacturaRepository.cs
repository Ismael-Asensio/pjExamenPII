using pjExamenPII.Data;
using pjExamenPII.Models;
using pjExamenPII.RepostoryF.IRepositoryF;

namespace pjExamenPII.RepostoryF
{
    public class DetalleFacturaRepository : Repostitory<DetalleFactura>, IDetallesFacturaRepository
    {
        private readonly FacturaContext _db;
        public DetalleFacturaRepository(FacturaContext db) : base(db)
        {
        }

        public async Task<DetalleFactura> Update(DetalleFactura enity)
        {
            _db.DetalleFacturas.Update(enity);
            await _db.SaveChangesAsync();
            return enity;
        }
    }
}
