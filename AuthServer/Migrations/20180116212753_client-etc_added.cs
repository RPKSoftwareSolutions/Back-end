using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuthServer.Migrations
{
    public partial class clientetc_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCorsOrigin_Clients_ClientId",
                table: "ClientCorsOrigin");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientGrantType_Clients_ClientId",
                table: "ClientGrantType");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientScope_Clients_ClientId",
                table: "ClientScope");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientScope",
                table: "ClientScope");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientGrantType",
                table: "ClientGrantType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCorsOrigin",
                table: "ClientCorsOrigin");

            migrationBuilder.RenameTable(
                name: "ClientScope",
                newName: "ClientScopes");

            migrationBuilder.RenameTable(
                name: "ClientGrantType",
                newName: "ClientGrantTypes");

            migrationBuilder.RenameTable(
                name: "ClientCorsOrigin",
                newName: "ClientCorsOrigins");

            migrationBuilder.RenameIndex(
                name: "IX_ClientScope_ClientId",
                table: "ClientScopes",
                newName: "IX_ClientScopes_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientGrantType_ClientId",
                table: "ClientGrantTypes",
                newName: "IX_ClientGrantTypes_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCorsOrigin_ClientId",
                table: "ClientCorsOrigins",
                newName: "IX_ClientCorsOrigins_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientScopes",
                table: "ClientScopes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientGrantTypes",
                table: "ClientGrantTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCorsOrigins",
                table: "ClientCorsOrigins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCorsOrigins_Clients_ClientId",
                table: "ClientCorsOrigins",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGrantTypes_Clients_ClientId",
                table: "ClientGrantTypes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientScopes_Clients_ClientId",
                table: "ClientScopes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCorsOrigins_Clients_ClientId",
                table: "ClientCorsOrigins");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientGrantTypes_Clients_ClientId",
                table: "ClientGrantTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientScopes_Clients_ClientId",
                table: "ClientScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientScopes",
                table: "ClientScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientGrantTypes",
                table: "ClientGrantTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCorsOrigins",
                table: "ClientCorsOrigins");

            migrationBuilder.RenameTable(
                name: "ClientScopes",
                newName: "ClientScope");

            migrationBuilder.RenameTable(
                name: "ClientGrantTypes",
                newName: "ClientGrantType");

            migrationBuilder.RenameTable(
                name: "ClientCorsOrigins",
                newName: "ClientCorsOrigin");

            migrationBuilder.RenameIndex(
                name: "IX_ClientScopes_ClientId",
                table: "ClientScope",
                newName: "IX_ClientScope_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientGrantTypes_ClientId",
                table: "ClientGrantType",
                newName: "IX_ClientGrantType_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCorsOrigins_ClientId",
                table: "ClientCorsOrigin",
                newName: "IX_ClientCorsOrigin_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientScope",
                table: "ClientScope",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientGrantType",
                table: "ClientGrantType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCorsOrigin",
                table: "ClientCorsOrigin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCorsOrigin_Clients_ClientId",
                table: "ClientCorsOrigin",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGrantType_Clients_ClientId",
                table: "ClientGrantType",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientScope_Clients_ClientId",
                table: "ClientScope",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
