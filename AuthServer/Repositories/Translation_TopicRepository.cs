using AuthServer.Auth; 
using AuthServer.Generic;
using AuthServer.RepoInterfaces;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Repositories
{
    public class Translation_TopicRepository: Repository<Translation_Topic>, ITranslation_TopicRepository
    {
        public Translation_TopicRepository(AppDbContext _context) : base(_context) { }

        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }
    }
}
