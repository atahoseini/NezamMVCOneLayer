using NezamMVCOneLayer.Models;

namespace NezamMVCOneLayer.DataAccess.Repository.IRepository
{
    public interface IElectRepository : IRepository<Elect>
    {
        void Update(Elect entity);
    }
}
