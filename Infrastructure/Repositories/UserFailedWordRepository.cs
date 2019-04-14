using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class UserLearnedWordRepository: Repository<UserLearnedWord>, IUserLearnedWordRepository
    {
        public UserLearnedWordRepository(AppDbContext context) : base(context) { }

        public AppDbContext AppContext => Context as AppDbContext;
    }
}
