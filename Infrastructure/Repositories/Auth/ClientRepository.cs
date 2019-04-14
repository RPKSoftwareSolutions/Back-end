using System.Collections.Generic;
using System.Linq;
using DomainModel.AuthenticateModels;
using Infrastructure.RepoInterfaces.Auth;
using Client = DomainModel.AuthenticateModels.Client;

namespace Infrastructure.Repositories.Auth
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext _context) : base(_context)
        {
        }


        public IEnumerable<ClientSecret> GetSecrets(string clientId)
        {
            int cid = AppContext.Clients.SingleOrDefault(c => c.ClientId == clientId).Id;
            return AppContext.ClientSecrets.Where(s => s.ClientId == cid).ToList();
        }

        public IEnumerable<ClientCorsOrigin> GetCorsOrigins(string clientId)
        {
            int cid = AppContext.Clients.SingleOrDefault(c => c.ClientId == clientId).Id;
            return AppContext.ClientCorsOrigins.Where(s => s.ClientId == cid).ToList();
        }

        public IEnumerable<ClientScope> GetScopes(string clientId)
        {
            int cid = AppContext.Clients.SingleOrDefault(c => c.ClientId == clientId).Id;
            return AppContext.ClientScopes.Where(s => s.ClientId == cid).ToList();
        }

        public IEnumerable<ClientGrantType> GetGrantTypes(string clientId)
        {
            int cid = AppContext.Clients.SingleOrDefault(c => c.ClientId == clientId).Id;
            return AppContext.ClientGrantTypes.Where(s => s.ClientId == cid).ToList();
        }

        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }

        
    }
}
