using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuthServer.Migrations
{
    public partial class uniqueindexesform2ms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint("SekaniRoots_EnglishWords_Unique", "SekaniRoots_EnglishWords", new string[] { "EnglishWordId", "SekaniRootId" }, null);
            migrationBuilder.AddUniqueConstraint("SekaniRoots_Topics_Unique", "SekaniRoots_Topics", new string[] { "SekaniRootId", "TopicId" }, null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint("SekaniRoots_EnglishWords_Unique", "SekaniRoots_EnglishWords");
            migrationBuilder.DropUniqueConstraint("SekaniRoots_Topics_Unique", "SekaniRoots_Topics");
        }
    }
}
