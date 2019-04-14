using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class SekaniWordAttributeRepository: Repository<SekaniWordAttribute>, ISekaniWordAttributeRepository
    {
        public SekaniWordAttributeRepository(AppDbContext _context) : base(_context) { }




        public AppDbContext AppContext => Context as AppDbContext;
    }
}
