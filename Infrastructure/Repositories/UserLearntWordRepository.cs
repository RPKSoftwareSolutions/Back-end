using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class UserFailedWordRepository: Repository<UserFailedWord>, IUserFailedWordRepository
    {
        public UserFailedWordRepository(AppDbContext context) : base(context) { }
        public AppDbContext AppContext => Context as AppDbContext;
    }
}
