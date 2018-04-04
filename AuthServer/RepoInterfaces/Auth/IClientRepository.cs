using AuthServer.Generic;
using DomainModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.RepoInterfaces
{
    public interface IClientRepository: IRepository<DomainModel.Client>
    {
        IEnumerable<ClientSecret> GetSecrets(string clientId);
        IEnumerable<ClientGrantType> GetGrantTypes(string clientId);
        IEnumerable<ClientCorsOrigin> GetCorsOrigins(string clientId);
        IEnumerable<ClientScope> GetScopes(string clientId);
    }
}
