using Microsoft.EntityFrameworkCore.Migrations;

namespace TKD.Infrastructure.Migrations
{
    public partial class DatInitial : Migration
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

            migrationBuilder.Sql(@"INSERT INTO dbo.SekaniLevels (  [Notes] , [Title], [UpdateTime])
            VALUES
                (N'', N'1', N'2018-07-18T03:01:53.37'),
            (N'', N'2', N'2018-07-18T03:01:53.37'), 
            (N'', N'3', N'2018-07-18T03:01:53.37' ), 
            (N'', N'4', N'2018-07-18T03:01:53.37' ), 
            (N'', N'5', N'2018-07-18T03:01:53.37' ), 
            (N'', N'6', N'2018-07-18T03:01:53.37' ), 
            (N'', N'7', N'2018-07-18T03:01:53.37' ), 
            (N'', N'8', N'2018-07-18T03:01:53.37' ), 
            (N'', N'9', N'2018-07-18T03:01:53.37' ), 
            (N'', N'10', N'2018-07-18T03:01:53.37' )");


            migrationBuilder.Sql(@"INSERT INTO dbo.UserActivityStats
            (
                UpdateTime,
                UserId,
                Value,
                Variable
            )
            VALUES
            (SYSDATETIME(),
                1,
                N'1',
            N'Level'
                ),
            (SYSDATETIME(),
                1,
                N'5',           
            N'Life'
                ),
            (SYSDATETIME(),
                1,
                N'0',           
            N'Score'
                ),
            (SYSDATETIME(),
                1,
                N'20',           
            N'TotalRoundCount'
                ),
            (SYSDATETIME(),
                1,
                N'20',           
            N'CorrectAnswersCount'
                ),
            (SYSDATETIME(),
                1,
                N'20',           
            N'FailedRoundCount'
                )");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
