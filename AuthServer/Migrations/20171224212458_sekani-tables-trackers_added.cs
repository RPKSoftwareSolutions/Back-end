using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuthServer.Migrations
{
    public partial class sekanitablestrackers_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TranslationsOfSekani",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "TranslationsOfSekani",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SekaniWWTs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "SekaniWWTs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SekaniWordTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "SekaniWordTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SekaniSound",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "SekaniSound",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SekaniPhotos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "SekaniPhotos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Levels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Levels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TranslationsOfSekani");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "TranslationsOfSekani");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SekaniWWTs");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "SekaniWWTs");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SekaniWordTypes");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "SekaniWordTypes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SekaniSound");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "SekaniSound");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SekaniPhotos");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "SekaniPhotos");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Levels");
        }
    }
}
