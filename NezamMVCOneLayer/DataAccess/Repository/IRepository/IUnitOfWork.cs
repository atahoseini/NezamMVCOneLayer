using System;

namespace NezamMVCOneLayer.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidRepository Candid { get; }
        IElectRepository Elect { get; }
        ICityRepository  City { get; }
        IFieldRepository Field { get; }
        IMemberRepository Member { get; }
        ISP_Call SP_Call { get; }
        void Save();
    }

}
