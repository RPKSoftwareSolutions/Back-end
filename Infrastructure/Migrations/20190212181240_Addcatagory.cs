using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Addcatagory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "SekaniCategories",
                nullable: true);
            migrationBuilder.Sql("UPDATE auth.Users SET SekaniLevelId=1");
            migrationBuilder.Sql(@"INSERT INTO auth.ClientScopes
                                  (
                                      ClientId,
                                      Scope
                                  )
                                  VALUES
                                      (1, --ClientId - int
                                  N'api1'-- Scope - nvarchar(max)
                                   )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "SekaniCategories");
        }
    }
}
