using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

using Infrastructure;
using TKD.DomainModel.AuthenticateModels;
using TKD.Infrastructure;

namespace AuthServer.Auth
{
    public class ClientStore : IClientStore
    {
        private UnitOfWork uow;
        private AppDbContext _context;

        public ClientStore(AppDbContext context)
        {
            this._context = context;
            this.uow = new UnitOfWork(this._context);
        }
        

        public Task<IdentityServer4.Models.Client> FindClientByIdAsync(string clientId)
        {
            var c = uow.Clients.Find(cl => cl.ClientId == clientId).FirstOrDefault();

            // preparing the secrets
            List<Secret> secrets = new List<Secret>();
            List<ClientSecret> cs = uow.Clients.GetSecrets(clientId).ToList();
            foreach(var s in cs)
            {
                secrets.Add(new Secret()
                {
                    Description = s.Description,
                    Expiration = s.Expiration,
                    Type = s.Type,
                    Value = s.Value
                });
            }

            // prepapring the allowed grant types
            List<string> grantTypes = uow.Clients.GetGrantTypes(clientId).Select(x => x.GrantType).ToList();

            // preparing scopes
            List<string> scopes = uow.Clients.GetScopes(clientId).Select(x => x.Scope).ToList();

            //prepare cors origins
            List<string> cors = uow.Clients.GetCorsOrigins(clientId).Select(x => x.Origin).ToList();

            IdentityServer4.Models.Client C = new IdentityServer4.Models.Client()
            {
                ClientId = c.ClientId,
                AllowOfflineAccess = c.AllowOfflineAccess,
                AccessTokenLifetime = c.AccessTokenLifeTime,
                // todo fix this shit:
                AllowedGrantTypes = grantTypes,
                //AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = secrets,
                AllowedScopes = scopes,
                AllowedCorsOrigins = cors,
                RefreshTokenExpiration = 0,
                SlidingRefreshTokenLifetime = c.SlidingRefreshTokenLifetime,
                Enabled = c.Enabled
            };
            return Task.FromResult(C);
        }
    }
}
