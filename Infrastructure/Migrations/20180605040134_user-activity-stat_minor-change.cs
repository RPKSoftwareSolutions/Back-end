using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace  Infrastructure.Migrations
{
    public partial class useractivitystat_minorchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity1Life",
                table: "UserActivityStats");

            migrationBuilder.DropColumn(
                name: "Activity2Life",
                table: "UserActivityStats");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "UserActivityStats");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "UserActivityStats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Variable",
                table: "UserActivityStats",
                nullable: true);

            //migrationBuilder.AddUniqueConstraint("User_Variable_Value_Unique", "UserActivityStats", new string[] { "Variable", "Value", "UserId" }, null);
            //migrationBuilder.AddUniqueConstraint("SekaniRoots_Topics_Unique", "SekaniRoots_Topics", new string[] { "SekaniRootId", "TopicId" }, null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "UserActivityStats");

            migrationBuilder.DropColumn(
                name: "Variable",
                table: "UserActivityStats");

            migrationBuilder.AddColumn<int>(
                name: "Activity1Life",
                table: "UserActivityStats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Activity2Life",
                table: "UserActivityStats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "UserActivityStats",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.DropUniqueConstraint("User_Variable_Value_Unique", "UserActivityStats");
        }
    }
}
