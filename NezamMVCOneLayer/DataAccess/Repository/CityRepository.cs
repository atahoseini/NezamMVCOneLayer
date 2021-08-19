using NezamMVCOneLayer.DataAccess;
using NezamMVCOneLayer.DataAccess.Repository.IRepository;
using NezamMVCOneLayer.Models;
using NezamMVCOneLayer.DataAccess.Data;
 
using System.Linq;

namespace NezamMVCOneLayer.DataAccess.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(City entity)
        {
            var objFromDb = _db.Cities.FirstOrDefault(s => s.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.CityName = entity.CityName;
            }
        }
    }

}
