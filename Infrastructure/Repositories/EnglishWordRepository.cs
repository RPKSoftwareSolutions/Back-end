using DomainModel;
using DomainModel.TKDModels;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class EnglishWordRepository: Repository<EnglishWord>, IEnglishWordRepository
    {
        public EnglishWordRepository(AppDbContext context) : base(context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
