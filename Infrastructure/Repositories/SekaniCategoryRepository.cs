
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniCategoryRepository: Repository<SekaniCategory>, ISekaniCategoryRepository
    {
        public SekaniCategoryRepository(AppDbContext context) : base(context) { }




        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }
    }
}
