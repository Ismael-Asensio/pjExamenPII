using pjExamenPII.Models;

namespace pjExamenPII.RepostoryF.IRepositoryF
{
    public interface IFacturasRepository : IRepository <Facturas>
    {
        Task<Facturas> Update(Facturas enity);
    }
}
