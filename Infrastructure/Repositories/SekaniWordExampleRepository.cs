using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class SekaniWordExampleRepository: Repository<SekaniWordExample>, ISekaniWordExampleRepository
    {
        public SekaniWordExampleRepository(AppDbContext context) : base(context) { }
    



        public AppDbContext AppContext => Context as AppDbContext;
    }
}
