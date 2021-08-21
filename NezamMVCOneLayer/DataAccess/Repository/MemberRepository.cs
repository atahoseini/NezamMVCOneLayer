 
using NezamMVCOneLayer.DataAccess.Repository.IRepository;
using NezamMVCOneLayer.Models;
using NezamMVCOneLayer.DataAccess.Data;
 
using System.Linq;

namespace NezamMVCOneLayer.DataAccess.Repository
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        private readonly ApplicationDbContext _db;

        public MemberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Member entity)
        {
            var objFromDb = _db.Members.FirstOrDefault(s => s.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.FirstName = entity.FirstName;
            }
        }
        public Member IsUserAuthenticated(string parvande, string password)
        {
            return _db.Members.FirstOrDefault(member => member.Parvandeh == parvande && member.Password == password);
        }
    }

}
