using pjExamenPII.Models;

namespace pjExamenPII.RepostoryF.IRepositoryF
{
    public interface IDetallesFacturaRepository : IRepository <DetalleFactura>
    {
        Task<DetalleFactura> Update(DetalleFactura enity);
    }
}
