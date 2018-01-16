using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuthServer.Migrations
{
    public partial class clientsecret_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientSecret_Clients_ClientId",
                table: "ClientSecret");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientSecret",
                table: "ClientSecret");

            migrationBuilder.RenameTable(
                name: "ClientSecret",
                newName: "ClientSecrets");

            migrationBuilder.RenameIndex(
                name: "IX_ClientSecret_ClientId",
                table: "ClientSecrets",
                newName: "IX_ClientSecrets_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientSecrets",
                table: "ClientSecrets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientSecrets_Clients_ClientId",
                table: "ClientSecrets",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientSecrets_Clients_ClientId",
                table: "ClientSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientSecrets",
                table: "ClientSecrets");

            migrationBuilder.RenameTable(
                name: "ClientSecrets",
                newName: "ClientSecret");

            migrationBuilder.RenameIndex(
                name: "IX_ClientSecrets_ClientId",
                table: "ClientSecret",
                newName: "IX_ClientSecret_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientSecret",
                table: "ClientSecret",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientSecret_Clients_ClientId",
                table: "ClientSecret",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
