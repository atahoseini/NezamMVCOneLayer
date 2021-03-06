 using NezamMVCOneLayer.DataAccess.Repository.IRepository;
using NezamMVCOneLayer.Models;
using NezamMVCOneLayer.DataAccess.Data;
 
using System.Linq;

namespace NezamMVCOneLayer.DataAccess.Repository
{
    public class ElectRepository : Repository<Elect>, IElectRepository
    {
        private readonly ApplicationDbContext _db;

        public ElectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Elect entity)
        {
            var objFromDb = _db.Elects.FirstOrDefault(s => s.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.Member = entity.Member;
            }
        }
    }

}
