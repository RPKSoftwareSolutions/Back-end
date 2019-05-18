
using TKD.Domain.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniRootRepository: Repository<SekaniRoot>, ISekaniRootRepository
    {
        public SekaniRootRepository(AppDbContext _context) : base(_context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
