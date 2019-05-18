
using TKD.Domain.TKDModels;
using TKD.Infrastructure.RepoInterfaces;

namespace TKD.Infrastructure.Repositories
{
    public class UserActivityStatRepository: Repository<UserActivityStat>, IUserActivityStatRepository
    {
        public UserActivityStatRepository(AppDbContext _context) : base(_context) { }
        public AppDbContext AppContext => Context as AppDbContext;
    }
}
