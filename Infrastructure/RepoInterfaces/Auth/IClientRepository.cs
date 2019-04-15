using System.Collections.Generic;
using Framework.Core;
using TKD.DomainModel.AuthenticateModels;
using Client = TKD.DomainModel.AuthenticateModels.Client;

namespace TKD.Infrastructure.RepoInterfaces.Auth
{
    public interface IClientRepository: IRepository<Client>
    {
        IEnumerable<ClientSecret> GetSecrets(string clientId);
        IEnumerable<ClientGrantType> GetGrantTypes(string clientId);
        IEnumerable<ClientCorsOrigin> GetCorsOrigins(string clientId);
        IEnumerable<ClientScope> GetScopes(string clientId);
    }
}
