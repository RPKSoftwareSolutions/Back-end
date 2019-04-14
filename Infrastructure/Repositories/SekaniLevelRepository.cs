using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class SekaniLevelRepository: Repository<SekaniLevel>, ISekaniLevelRepository
    {
        public SekaniLevelRepository(AppDbContext context) : base(context) { }
        public AppDbContext AppContext => Context as AppDbContext;
    }
}
