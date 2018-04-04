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
    public class SekaniRoot_EnglishWordRepository: Repository<SekaniRoot_EnglishWord>, ISekaniRoot_EnglishWordRepository
    {
        public SekaniRoot_EnglishWordRepository(AppDbContext _context) : base(_context) { }




        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }
    }
}
