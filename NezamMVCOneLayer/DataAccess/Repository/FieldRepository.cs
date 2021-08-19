 
using NezamMVCOneLayer.DataAccess.Repository.IRepository;
using NezamMVCOneLayer.Models;
using NezamMVCOneLayer.DataAccess.Data;
 
using System.Linq;

namespace NezamMVCOneLayer.DataAccess.Repository
{
    public class FieldRepository : Repository<Field>, IFieldRepository
    {
        private readonly ApplicationDbContext _db;

        public FieldRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Field entity)
        {
            var objFromDb = _db.Fields.FirstOrDefault(s => s.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.FieldName = entity.FieldName;
            }
        }
    }

}
