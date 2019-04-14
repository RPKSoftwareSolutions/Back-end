using DomainModel.AuthenticateModels;
using Infrastructure.RepoInterfaces.Auth;

namespace Infrastructure.Repositories.Auth
{
    public class UserSessionRepository: Repository<UserSession>, IUserSessionRepository
    {
        public UserSessionRepository(AppDbContext _context) : base(_context) { }

        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }
    }
}
