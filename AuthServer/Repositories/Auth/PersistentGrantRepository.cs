using AuthServer.Generic;
using AuthServer.RepoInterfaces;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthServer.Auth;

namespace AuthServer.Repositories
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
