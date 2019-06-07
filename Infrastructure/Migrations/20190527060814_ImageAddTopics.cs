using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TKD.Infrastructure.Migrations
{
    public partial class ImageAddTopics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "LockImage",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "UnlockImage",
                table: "Topics",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockImage",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UnlockImage",
                table: "Topics");
        }
    }
}
