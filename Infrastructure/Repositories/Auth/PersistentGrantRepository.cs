using Microsoft.EntityFrameworkCore;
using TKD.Domain.AuthenticateModels;
using TKD.DomainModel.AuthenticateModels;
using TKD.Infrastructure.RepoInterfaces.Auth;

namespace TKD.Infrastructure.Repositories.Auth
{
    public class PersistentGrantRepository : Repository<PersistedGrant>, IPersistedGrantRepository
    {
        public PersistentGrantRepository(DbContext _context) : base(_context)
        {
        }

        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }
    }
}
