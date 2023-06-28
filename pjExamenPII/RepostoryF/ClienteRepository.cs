using pjExamenPII.Data;
using pjExamenPII.Models;
using pjExamenPII.RepostoryF.IRepositoryF;

namespace pjExamenPII.RepostoryF
{
    public class ClienteRepository : Repostitory <Clientes>, IClientesRepositoy
    {
        private readonly FacturaContext _db;

        public ClienteRepository(FacturaContext db) : base(db)
        {
        }

        public async Task<Clientes> Update(Clientes enity)
        {
            _db.Clientes.Update(enity);
            await _db.SaveChangesAsync();
            return enity;
        }
    }
}
