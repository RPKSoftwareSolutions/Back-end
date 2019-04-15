
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniWordRepository: Repository<SekaniWord>, ISekaniWordRepository
    {
        public SekaniWordRepository(AppDbContext _context): base(_context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
