
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniWordAttributeRepository: Repository<SekaniWordAttribute>, ISekaniWordAttributeRepository
    {
        public SekaniWordAttributeRepository(AppDbContext _context) : base(_context) { }




        public AppDbContext AppContext => Context as AppDbContext;
    }
}
