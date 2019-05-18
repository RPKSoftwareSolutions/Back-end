using TKD.Domain.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class UserLearnedWordRepository: Repository<UserLearnedWord>, IUserLearnedWordRepository
    {
        public UserLearnedWordRepository(AppDbContext context) : base(context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
