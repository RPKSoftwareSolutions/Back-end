﻿using AuthServer.Uow;
using DomainModel;
using IdentityServer4.Validation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace AuthServer.Auth
{
    public class FacebookGrant : IExtensionGrantValidator
    {
        public string GrantType
        {
            get
            {
                return "facebookAuth";
            }
        }

        private AppDbContext _context;
        public FacebookGrant(AppDbContext context)
        {
            this._context = context;
        }


        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {

            /* the "access_token" is generated by facebook after user logs in to Facebook, and in exchange an "access_token" can be retrieved.
             * What facebook calls "access_token" is equivalent to what google calls "id_token" and IT IS DIFFERENT FROM THE "access_token" THAT
             * OUR AUTH SERVER WILL EVENTUALLY ISSUE TO THE USER.
             * ** Please look at my comments on "GoogleGrant.cs" file for the similar block.
             * 
             */
            var userToken = context.Request.Raw.Get("access_token");

            if (string.IsNullOrEmpty(userToken))
            {
                context.Result = new GrantValidationResult(TokenErrors.InvalidGrant, null);
                return;
            }

            HttpClient client = new HttpClient();

            var request = client.GetAsync("https://graph.facebook.com/me?fields=email,first_name,last_name,verified&access_token=" + userToken).Result;

            if (request.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await request.Content.ReadAsStringAsync();
                var obj = JObject.Parse(result);
                var FacebookUser = new FacebookUserObject
                {
                    Email = obj["email"].ToString(),
                    EmailVerified = bool.Parse(obj["verified"].ToString()),
                    FirstName = obj["first_name"].ToString(),
                    LastName = obj["last_name"].ToString(),
                };

                var U = new UnitOfWork(this._context);
                var userExists = U.Auth.Find(u => u.Email == FacebookUser.Email).Count() > 0;

                if (!userExists)
                {
                    var newUser = new User
                    {
                        Email = FacebookUser.Email,
                        EmailVerified = FacebookUser.EmailVerified,
                        FirstName = FacebookUser.FirstName,
                        LastName = FacebookUser.LastName,
                        PhoneNumber = "",
                        PhoneNumberVerified = false,
                        Password = "N/A",
                        Username = FacebookUser.Email,
                        Active = FacebookUser.EmailVerified
                    };
                    U.Auth.Add(newUser);
                    U.Complete();
                }

                var authUser = U.Auth.Find(u => u.Email == FacebookUser.Email).FirstOrDefault();
                context.Result = new GrantValidationResult(authUser.Id.ToString(), "facebook");
                //context.Result = new GrantValidationResult(authU)
                return;
            }
            else
            {
                return;
            }
        }
    }

    public class FacebookUserObject
    {
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
