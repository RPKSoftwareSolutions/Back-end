using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace AuthServer.Auth
{
    public class RefreshTokenStore : IRefreshTokenStore
    {
        public Task<RefreshToken> GetRefreshTokenAsync(string refreshTokenHandle)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRefreshTokenAsync(string refreshTokenHandle)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRefreshTokensAsync(string subjectId, string clientId)
        {
            throw new NotImplementedException();
        }

        public Task<string> StoreRefreshTokenAsync(RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRefreshTokenAsync(string handle, RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
