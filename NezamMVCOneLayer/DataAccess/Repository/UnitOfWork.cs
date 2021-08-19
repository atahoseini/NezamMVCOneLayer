 
using NezamMVCOneLayer.DataAccess.Repository.IRepository;
using NezamMVCOneLayer.DataAccess.Data;

namespace NezamMVCOneLayer.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Candid = new CandidRepository(_db);
            City = new CityRepository(_db);
            Elect = new ElectRepository(_db);
            Field = new FieldRepository(_db);
            Member = new MemberRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public ICandidRepository Candid { get; private set; }
        public ICityRepository City { get; private set; }
        public IElectRepository Elect { get; private set; }
        public IFieldRepository Field { get; private set; }
        public IMemberRepository Member { get; private set; }

        public ISP_Call SP_Call { get; private set; }

          public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }

}
