using pjExamenPII.Models;

namespace pjExamenPII.RepostoryF.IRepositoryF
{
    public interface IProductosRepository : IRepository <Productos>
    {
        Task<Productos> Update(Productos enity);
    }
}
