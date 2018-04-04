using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuthServer.Migrations
{
    public partial class initial_auth_records : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO auth.Users(Email, EmailVerified, Password, Username, Active, PhoneNumberVerified) Values('beh_66@yahoo.com', 1, '"
                                + CryptoHelper.Crypto.HashPassword("bbcliqa") + "', 'beh_66@yahoo.com', 1, 0);");

            migrationBuilder.Sql(@"INSERT INTO auth.Clients(AccessTokenLifeTime, AllowOfflineAccess, ClientId, Enabled, RefreshTokenExpiration, SlidingRefreshTokenLifetime) 
                                   VALUES(3600, 1, 'resourceOwner', 1, 0, 196000);");

            migrationBuilder.Sql(@"INSERT INTO auth.ClientGrantTypes(ClientId, GrantType)
                                   VALUES(1, 'password');");

            migrationBuilder.Sql(@"INSERT INTO auth.ClientCorsOrigins(ClientId, Origin)
                                   VALUES(1, 'http://localhost:4200');");

            migrationBuilder.Sql(@"INSERT INTO auth.ClientSecrets(ClientId, Expiration, Type, Value)
                                   VALUES(1, '2019-10-10', 'SharedSecret', 'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=');");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM auth.Users WHERE Email='beh_66@yahoo.com';");
        }
    }
}
