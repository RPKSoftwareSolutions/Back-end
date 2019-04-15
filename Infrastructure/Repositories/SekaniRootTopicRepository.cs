
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniRootTopicRepository: Repository<SekaniRootTopic>, ISekaniRootTopicRepository
    {
        public SekaniRootTopicRepository(AppDbContext context) : base(context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
