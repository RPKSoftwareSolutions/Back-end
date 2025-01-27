﻿using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using TKD.Infrastructure;

namespace AuthServer.Auth
{
    public class ProfileService : IProfileService
    {
        private AppDbContext context;
        public ProfileService(AppDbContext _context)
        {
            this.context = _context;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var UoW = new UnitOfWork(this.context);
                var subjectId = int.Parse(context.Subject.GetSubjectId());
                var user = UoW.Auth.Get(subjectId);

                var claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                    new Claim(JwtClaimTypes.Email, user.Email),
				    // keep adding as many claims as you want
                    // ...
			    };
                var dbClaims = UoW.Auth.GetUserClaims(user.Id);
                foreach (var c in dbClaims)
                {
                    claims.Add(new Claim(c.ClaimType, c.ClaimValue));
                }
                context.IssuedClaims = claims;

                return Task.FromResult(0);
            }
            catch (Exception x)
            {
                return Task.FromResult(0);
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            
            //var user = repo.GetById(int.Parse(context.Subject.GetSubjectId()));
            var user = new UnitOfWork(this.context).Auth.Get(int.Parse(context.Subject.GetSubjectId()));
            context.IsActive = (user != null) && user.Active;
            return Task.FromResult(0);
        }
    }
}
