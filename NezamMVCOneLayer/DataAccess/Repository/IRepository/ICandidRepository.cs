using NezamMVCOneLayer.Models;
 

namespace NezamMVCOneLayer.DataAccess.Repository.IRepository
{
    public interface ICandidRepository : IRepository<Candid>
    {
        void Update(Candid entity);
    }
}
