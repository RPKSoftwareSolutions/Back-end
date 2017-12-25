using AuthServer.Uow;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Auth
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator 
    {
        //private IAuthRepository repo;
        private AppDbContext _context;

        public ResourceOwnerPasswordValidator(AppDbContext context)
        {
            //this.repo = auth;
            this._context = context;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var uow = new UnitOfWork(this._context);

            if (uow.Auth.ValidatePassword(context.UserName, context.Password))
            {
                var z = uow.Auth.Find(u => u.Username == context.UserName);
                var en = z.GetEnumerator();
                int userId = 0;
                while (en.MoveNext())
                {
                    userId = en.Current.Id;
                }

                context.Result = new GrantValidationResult(userId.ToString(), "password", null, "local", null);
                return Task.FromResult(context.Result);
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
            return Task.FromResult(context.Result);
        }
    }
}
