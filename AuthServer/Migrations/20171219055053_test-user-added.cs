using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuthServer.Migrations
{
    public partial class testuseradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.Users(Email, EmailVerified, Password, Username, Active, PhoneNumberVerified) Values('beh_66@yahoo.com', 1, '" 
                                + CryptoHelper.Crypto.HashPassword("bbcliqa") + "', 'beh_66@yahoo.com', 1, 0);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM dbo.Users WHERE Email='beh_66@yahoo.com';");
        }
    }
}
