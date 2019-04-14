using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class SekaniWordRepository: Repository<SekaniWord>, ISekaniWordRepository
    {
        public SekaniWordRepository(AppDbContext _context): base(_context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
