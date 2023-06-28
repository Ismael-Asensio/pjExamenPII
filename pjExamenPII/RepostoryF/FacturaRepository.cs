using pjExamenPII.Data;
using pjExamenPII.Models;
using pjExamenPII.RepostoryF.IRepositoryF;

namespace pjExamenPII.RepostoryF
{
    public class FacturaRepository : Repostitory<Facturas>, IFacturasRepository
    {
        private readonly FacturaContext _db;
        public FacturaRepository(FacturaContext db) : base(db)
        {
        }

        public async Task<Facturas> Update(Facturas enity)
        {
            _db.Facturas.Update(enity);
            await _db.SaveChangesAsync();
            return enity;
        }
    }
}
