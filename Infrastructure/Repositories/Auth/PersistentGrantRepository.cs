using DomainModel.AuthenticateModels;
using Infrastructure.RepoInterfaces.Auth;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Auth
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
