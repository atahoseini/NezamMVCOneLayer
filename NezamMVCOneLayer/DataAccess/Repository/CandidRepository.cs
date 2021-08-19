using NezamMVCOneLayer.DataAccess;
using NezamMVCOneLayer.DataAccess.Repository.IRepository;
using NezamMVCOneLayer.Models;
using NezamMVCOneLayer.DataAccess.Data;
 
using System.Linq;

namespace NezamMVCOneLayer.DataAccess.Repository
{
    public class CandidRepository : Repository<Candid>, ICandidRepository
    {
        private readonly ApplicationDbContext _db;

        public CandidRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Candid entity)
        {
            var objFromDb = _db.Candids.FirstOrDefault(s => s.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.FirstName = entity.FirstName;
            }
        }
    }

}
