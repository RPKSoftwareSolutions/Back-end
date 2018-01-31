using AuthServer.Uow;
using DomainModel;
using IdentityModel.Client;
using IdentityServer4.Events;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
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
        private UnitOfWork uow;
        private IEventService _events;

        protected readonly IRefreshTokenStore RefreshTokenStore;

        public ResourceOwnerPasswordValidator(AppDbContext context, IEventService events/*, IRefreshTokenStore _RefreshTokenStore*/)
        {
            //this.repo = auth;
            this._context = context;
            this.uow = new UnitOfWork(this._context);
            this._events = events;
            //this.RefreshTokenStore = _RefreshTokenStore;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //var uow = new UnitOfWork(this._context);

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
                this.UpdateUserSession(context, userId);
                
                return Task.FromResult(context.Result);
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
            return Task.FromResult(context.Result);
        }

        private void UpdateUserSession(ResourceOwnerPasswordValidationContext context, int userId)
        {
            var sessionId = context.Request.Raw.Get("session_id");
            var deviceId = context.Request.Raw.Get("device_id");
            var browser = context.Request.Raw.Get("browser");
            var os = context.Request.Raw.Get("os");
            UserSession US = uow.UserSessions.Find(us => us.UserId == userId && String.Equals(us.DeviceId, deviceId)).FirstOrDefault();
            if (US == null)
            {
                var newUs = new UserSession()
                {
                    UserId = userId,
                    SessionId = sessionId,
                    DeviceId = deviceId,
                    UpdateTime = DateTime.Now,
                    Browser = browser,
                    OperatingSystem = os
                };
                uow.UserSessions.Add(newUs);
                uow.Complete();
            }
            else
            {
                US.UpdateTime = DateTime.Now;
                uow.Complete();
            }
        }
    }
}
