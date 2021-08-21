using NezamMVCOneLayer.DataAccess.Repository.IRepository;
using NezamMVCOneLayer.Models;

namespace NezamMVCOneLayer.Services.Members
{
    public interface IIsUserAuthenticatedService
    {
        Member Execute(string parvande, string password);
    }

    public class IsUserAuthenticatedService : IIsUserAuthenticatedService
    {
        private readonly IUnitOfWork unitWork;

        public IsUserAuthenticatedService(IUnitOfWork unitWork)
        {
            this.unitWork = unitWork;
        }

        public Member Execute(string parvande, string password)
        {
            if (string.IsNullOrEmpty(parvande) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            return unitWork.Member.IsUserAuthenticated(parvande, password);
        }
    }
}