using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using System.Security.Claims;

namespace AuthServer.Auth
{
    public class RefreshTokenService : IRefreshTokenService
    {
        public Task<string> CreateRefreshTokenAsync(ClaimsPrincipal subject, Token accessToken, Client client)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateRefreshTokenAsync(string handle, RefreshToken refreshToken, Client client)
        {
            throw new NotImplementedException();
        }
    }
}
