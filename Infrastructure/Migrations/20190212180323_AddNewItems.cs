using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddNewItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLearntWords");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "SekaniLevels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserLearnedWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    SekaniWordId = table.Column<int>(nullable: false),
                    TryCount = table.Column<int>(nullable: false),
                    AnswerDateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLearnedWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLearnedWords_SekaniWords_SekaniWordId",
                        column: x => x.SekaniWordId,
                        principalTable: "SekaniWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLearnedWords_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLearnedWords_SekaniWordId",
                table: "UserLearnedWords",
                column: "SekaniWordId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLearnedWords_UserId",
                table: "UserLearnedWords",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLearnedWords");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "SekaniLevels");

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
                name: "IX_UserLearntWords_SekaniWordId",
                table: "UserLearntWords",
                column: "SekaniWordId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLearntWords_UserId",
                table: "UserLearntWords",
                column: "UserId");
        }
    }
}
