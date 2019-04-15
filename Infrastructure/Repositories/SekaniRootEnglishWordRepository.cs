
using TKD.DomainModel.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class SekaniRootEnglishWordRepository: Repository<SekaniRootEnglishWord>, ISekaniRootEnglishWordRepository
    {
        public SekaniRootEnglishWordRepository(AppDbContext context) : base(context) { }




        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }
    }
}
