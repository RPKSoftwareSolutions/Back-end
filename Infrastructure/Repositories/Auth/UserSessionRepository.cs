using TKD.DomainModel.AuthenticateModels;
using TKD.Infrastructure.RepoInterfaces.Auth;

namespace TKD.Infrastructure.Repositories.Auth
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
