using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuthServer.Migrations
{
    public partial class formtoroot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SekaniWords_SekaniForms_SekaniFormId",
                table: "SekaniWords");

            migrationBuilder.DropIndex(
                name: "IX_SekaniWords_SekaniFormId",
                table: "SekaniWords");

            migrationBuilder.DropColumn(
                name: "SekaniFormId",
                table: "SekaniWords");

            migrationBuilder.AddColumn<int>(
                name: "SekaniFormId",
                table: "SekaniRoots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SekaniRoots_SekaniFormId",
                table: "SekaniRoots",
                column: "SekaniFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_SekaniRoots_SekaniForms_SekaniFormId",
                table: "SekaniRoots",
                column: "SekaniFormId",
                principalTable: "SekaniForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SekaniRoots_SekaniForms_SekaniFormId",
                table: "SekaniRoots");

            migrationBuilder.DropIndex(
                name: "IX_SekaniRoots_SekaniFormId",
                table: "SekaniRoots");

            migrationBuilder.DropColumn(
                name: "SekaniFormId",
                table: "SekaniRoots");

            migrationBuilder.AddColumn<int>(
                name: "SekaniFormId",
                table: "SekaniWords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWords_SekaniFormId",
                table: "SekaniWords",
                column: "SekaniFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_SekaniWords_SekaniForms_SekaniFormId",
                table: "SekaniWords",
                column: "SekaniFormId",
                principalTable: "SekaniForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
