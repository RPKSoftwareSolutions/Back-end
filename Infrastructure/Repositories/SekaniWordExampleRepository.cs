
using TKD.Domain.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniWordExampleRepository: Repository<SekaniWordExample>, ISekaniWordExampleRepository
    {
        public SekaniWordExampleRepository(AppDbContext context) : base(context) { }
    



        public AppDbContext AppContext => Context as AppDbContext;
    }
}
