using NezamMVCOneLayer.Models;

namespace NezamMVCOneLayer.DataAccess.Repository.IRepository
{
    public interface IMemberRepository : IRepository<Member>
    {
        void Update(Member entity);
    }
}
