
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniLevelRepository: Repository<SekaniLevel>, ISekaniLevelRepository
    {
        public SekaniLevelRepository(AppDbContext context) : base(context) { }
        public AppDbContext AppContext => Context as AppDbContext;
    }
}
