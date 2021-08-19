using NezamMVCOneLayer.Models;
 

namespace NezamMVCOneLayer.DataAccess.Repository.IRepository
{
    public interface ICityRepository : IRepository<City>
    {
        void Update(City entity);
    }
}
