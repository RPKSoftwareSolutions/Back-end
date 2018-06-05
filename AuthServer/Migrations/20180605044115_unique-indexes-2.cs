using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuthServer.Migrations
{
    public partial class uniqueindexes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint("UserId_SekaniWordId_Unique1", "UserLearntWords", new string[] { "UserId", "SekaniWordId" }, null);
            migrationBuilder.AddUniqueConstraint("UserId_SekaniWordId_Unique2", "UserFailedWords", new string[] { "UserId", "SekaniWordId" }, null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint("UserId_SekaniWordId_Unique1", "UserLearntWords");
            migrationBuilder.DropUniqueConstraint("UserId_SekaniWordId_Unique2", "UserFailedWords");
        }
    }
}
