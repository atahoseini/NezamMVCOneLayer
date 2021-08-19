using NezamMVCOneLayer.Models;

namespace NezamMVCOneLayer.DataAccess.Repository.IRepository
{
    public interface IFieldRepository : IRepository<Field>
    {
        void Update(Field entity);
    }
}
