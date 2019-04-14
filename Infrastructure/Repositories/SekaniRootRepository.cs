using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class SekaniRootRepository: Repository<SekaniRoot>, ISekaniRootRepository
    {
        public SekaniRootRepository(AppDbContext _context) : base(_context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
