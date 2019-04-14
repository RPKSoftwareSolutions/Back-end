using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class SekaniRootImageRepository: Repository<SekaniRootImage>, ISekaniRootImageRepository
    {
        public SekaniRootImageRepository(AppDbContext context) : base(context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
