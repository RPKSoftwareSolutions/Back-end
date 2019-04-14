using DomainModel;
using Infrastructure.RepoInterfaces;

namespace Infrastructure.Repositories
{
    public class UserActivityStatRepository: Repository<UserActivityStat>, IUserActivityStatRepository
    {
        public UserActivityStatRepository(AppDbContext _context) : base(_context) { }
        public AppDbContext AppContext => Context as AppDbContext;
    }
}
