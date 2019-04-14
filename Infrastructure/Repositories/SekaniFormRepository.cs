using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class SekaniFormRepository: Repository<SekaniForm>, ISekaniFormRepository
    {
        public SekaniFormRepository(AppDbContext context) : base(context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
