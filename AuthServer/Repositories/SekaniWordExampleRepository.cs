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
    public class SekaniWordExampleRepository: Repository<SekaniWordExample>, ISekaniWordExampleRepository
    {
        public SekaniWordExampleRepository(AppDbContext _context) : base(_context) { }




        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }
    }
}
