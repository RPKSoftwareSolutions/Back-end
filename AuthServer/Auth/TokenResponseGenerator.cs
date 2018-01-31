using IdentityServer4.ResponseHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Validation;

namespace AuthServer.Auth
{
    public class TokenResponseGenerator : ITokenResponseGenerator
    {
        public Task<TokenResponse> ProcessAsync(TokenRequestValidationResult validationResult)
        {
            throw new NotImplementedException();
        }
    }
}
