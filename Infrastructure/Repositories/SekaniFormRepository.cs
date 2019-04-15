
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniFormRepository: Repository<SekaniForm>, ISekaniFormRepository
    {
        public SekaniFormRepository(AppDbContext context) : base(context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
