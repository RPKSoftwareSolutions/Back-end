
using TKD.Domain.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class UserFailedWordRepository: Repository<UserFailedWord>, IUserFailedWordRepository
    {
        public UserFailedWordRepository(AppDbContext context) : base(context) { }
        public AppDbContext AppContext => Context as AppDbContext;
    }
}
