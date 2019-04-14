using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class SekaniRootTopicRepository: Repository<SekaniRootTopic>, ISekaniRoot_TopicRepository
    {
        public SekaniRootTopicRepository(AppDbContext context) : base(context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
