using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class SekaniRootEnglishWordRepository: Repository<SekaniRootEnglishWord>, ISekaniRoot_EnglishWordRepository
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
