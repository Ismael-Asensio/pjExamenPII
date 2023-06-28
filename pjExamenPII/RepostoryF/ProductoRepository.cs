using pjExamenPII.Data;
using pjExamenPII.Models;
using pjExamenPII.RepostoryF.IRepositoryF;

namespace pjExamenPII.RepostoryF
{
    public class ProductoRepository : Repostitory <Productos>, IProductosRepository
    {
        private readonly FacturaContext _db;

        public ProductoRepository(FacturaContext db) : base(db)
        {
            _db = db;

        }
        public async Task<Productos> Update(Productos enity)
        {
            _db.Productos.Update(enity);
            await _db.SaveChangesAsync();
            return enity;
        }
    }
}
