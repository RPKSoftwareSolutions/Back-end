using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace  Infrastructure.Migrations
{
    public partial class activity_tracking_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

           /* migrationBuilder.RenameTable(
                name: "UserSessions",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "Users",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "PersistedGrants",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "PasswordResetTokens",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "EmailVerificationTokens",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "ClientSecrets",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "ClientScopes",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "Clients",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "ClientGrantTypes",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "ClientCorsOrigins",
                newSchema: "auth");*/

            migrationBuilder.AddColumn<int>(
                name: "SekaniLevelId",
                schema: "auth",
                table: "Users",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserActivityStats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activity1Life = table.Column<int>(nullable: false),
                    Activity2Life = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActivityStats_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFailedWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SekaniWordId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFailedWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFailedWords_SekaniWords_SekaniWordId",
                        column: x => x.SekaniWordId,
                        principalTable: "SekaniWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFailedWords_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLearntWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SekaniWordId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLearntWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLearntWords_SekaniWords_SekaniWordId",
                        column: x => x.SekaniWordId,
                        principalTable: "SekaniWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLearntWords_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SekaniLevelId",
                schema: "auth",
                table: "Users",
                column: "SekaniLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityStats_UserId",
                table: "UserActivityStats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFailedWords_SekaniWordId",
                table: "UserFailedWords",
                column: "SekaniWordId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFailedWords_UserId",
                table: "UserFailedWords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLearntWords_SekaniWordId",
                table: "UserLearntWords",
                column: "SekaniWordId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLearntWords_UserId",
                table: "UserLearntWords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SekaniLevels_SekaniLevelId",
                schema: "auth",
                table: "Users",
                column: "SekaniLevelId",
                principalTable: "SekaniLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SekaniLevels_SekaniLevelId",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserActivityStats");

            migrationBuilder.DropTable(
                name: "UserFailedWords");

            migrationBuilder.DropTable(
                name: "UserLearntWords");

            migrationBuilder.DropIndex(
                name: "IX_Users_SekaniLevelId",
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SekaniLevelId",
                schema: "auth",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserSessions",
                schema: "auth");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "auth");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "auth");

            migrationBuilder.RenameTable(
                name: "PersistedGrants",
                schema: "auth");

            migrationBuilder.RenameTable(
                name: "PasswordResetTokens",
                schema: "auth");

            migrationBuilder.RenameTable(
                name: "EmailVerificationTokens",
                schema: "auth");

            migrationBuilder.RenameTable(
                name: "ClientSecrets",
                schema: "auth");

            migrationBuilder.RenameTable(
                name: "ClientScopes",
                schema: "auth");

            migrationBuilder.RenameTable(
                name: "Clients",
                schema: "auth");

            migrationBuilder.RenameTable(
                name: "ClientGrantTypes",
                schema: "auth");

            migrationBuilder.RenameTable(
                name: "ClientCorsOrigins",
                schema: "auth");
        }
    }
}
