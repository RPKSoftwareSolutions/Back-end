using System.Collections.Generic;
using System.Linq;
using TKD.Domain.AuthenticateModels;
using TKD.DomainModel.AuthenticateModels;
using TKD.Infrastructure.RepoInterfaces.Auth;
using Client = TKD.DomainModel.AuthenticateModels.Client;

namespace TKD.Infrastructure.Repositories.Auth
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
