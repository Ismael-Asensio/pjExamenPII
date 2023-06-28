using pjExamenPII.Models;

namespace pjExamenPII.RepostoryF.IRepositoryF
{
    public interface IClientesRepositoy : IRepository <Clientes>
    {
        Task<Clientes> Update(Clientes enity);
    }
}
