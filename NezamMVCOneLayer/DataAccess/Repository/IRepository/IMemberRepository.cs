using NezamMVCOneLayer.Models;

namespace NezamMVCOneLayer.DataAccess.Repository.IRepository
{
    public interface IMemberRepository : IRepository<Member>
    {
        Member IsUserAuthenticated(string parvande, string password);
        void Update(Member entity);
    }
}
