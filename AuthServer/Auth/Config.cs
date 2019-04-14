//using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Auth
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "Main Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "resourceOwner",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        "offline_access",
                        "api1"
                    },
                    AllowOfflineAccess = true,                   
                    AccessTokenLifetime = 3600,
                    AllowedCorsOrigins = new List<string>
                    {
                        // add the origin URLs of your requesting apps here:
                        "http://localhost:4200/"
                    },
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    SlidingRefreshTokenLifetime = 1296000,
                    Enabled = true
                }
            };
        }
    }
}
