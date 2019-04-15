using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Infrastructure;
using TKD.Infrastructure;
using PersistedGrant = TKD.DomainModel.AuthenticateModels.PersistedGrant;

namespace AuthServer.Auth
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        //private readonly ILogger logger;
        //private readonly IPersistedGrantService persistedGrantService;

        private AppDbContext _context;
        private UnitOfWork uow;

        public PersistedGrantStore(AppDbContext context)
        {
            this._context = context;
            this.uow = new UnitOfWork(this._context);
        }

        public Task<IEnumerable<IdentityServer4.Models.PersistedGrant>> GetAllAsync(string subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityServer4.Models.PersistedGrant> GetAsync(string key)
        {
            var pg = uow.PersistedGrants.Find(p => p.Key == key).FirstOrDefault();
            if (pg == null)
                return Task.FromResult<IdentityServer4.Models.PersistedGrant>(null);
            IdentityServer4.Models.PersistedGrant ps = new IdentityServer4.Models.PersistedGrant()
            {
                ClientId = pg.ClientId,
                CreationTime = pg.CreationTime,
                Data = pg.Data,
                Expiration = pg.Expiration,
                Key = pg.Key,
                SubjectId = pg.SubjectId,
                Type = pg.Type
            };
            
            return Task.FromResult<IdentityServer4.Models.PersistedGrant>(ps);
        }

        public Task RemoveAllAsync(string subjectId, string clientId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            var pg = uow.PersistedGrants.Find(p => p.Key == key).FirstOrDefault();

            if (pg == null)
                throw new KeyNotFoundException();
            uow.PersistedGrants.Remove(pg);
            uow.Complete();
            return Task.CompletedTask;
        }

        public Task StoreAsync(IdentityServer4.Models.PersistedGrant grant)
        {
            //grant.

            

            uow.PersistedGrants.Add(new PersistedGrant()
            {
                ClientId = grant.ClientId,
                CreationTime = grant.CreationTime,
                Data = grant.Data,
                Expiration = grant.Expiration,
                Key = grant.Key,
                SubjectId = grant.SubjectId,
                Type = grant.Type
            });
            uow.Complete();

            //throw new NotImplementedException();
            return Task.CompletedTask;
        }
    }
}
