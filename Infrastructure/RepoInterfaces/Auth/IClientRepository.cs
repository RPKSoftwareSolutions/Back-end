using System.Collections.Generic;
using DomainModel.AuthenticateModels;
using Framework.Core;
using Client = DomainModel.AuthenticateModels.Client;

namespace Infrastructure.RepoInterfaces.Auth
{
    public interface IClientRepository: IRepository<Client>
    {
        IEnumerable<ClientSecret> GetSecrets(string clientId);
        IEnumerable<ClientGrantType> GetGrantTypes(string clientId);
        IEnumerable<ClientCorsOrigin> GetCorsOrigins(string clientId);
        IEnumerable<ClientScope> GetScopes(string clientId);
    }
}
