using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangeSomeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SekaniRoots_EnglishWords");

            migrationBuilder.DropTable(
                name: "SekaniRoots_Topics");

            migrationBuilder.CreateTable(
                name: "SekaniRootsEnglishWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnglishWordId = table.Column<int>(nullable: false),
                    SekaniRootId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniRootsEnglishWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniRootsEnglishWords_EnglishWords_EnglishWordId",
                        column: x => x.EnglishWordId,
                        principalTable: "EnglishWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SekaniRootsEnglishWords_SekaniRoots_SekaniRootId",
                        column: x => x.SekaniRootId,
                        principalTable: "SekaniRoots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SekaniRootsTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SekaniRootId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniRootsTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniRootsTopics_SekaniRoots_SekaniRootId",
                        column: x => x.SekaniRootId,
                        principalTable: "SekaniRoots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SekaniRootsTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SekaniRootsEnglishWords_EnglishWordId",
                table: "SekaniRootsEnglishWords",
                column: "EnglishWordId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniRootsEnglishWords_SekaniRootId",
                table: "SekaniRootsEnglishWords",
                column: "SekaniRootId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniRootsTopics_SekaniRootId",
                table: "SekaniRootsTopics",
                column: "SekaniRootId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniRootsTopics_TopicId",
                table: "SekaniRootsTopics",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SekaniRootsEnglishWords");

            migrationBuilder.DropTable(
                name: "SekaniRootsTopics");

            migrationBuilder.CreateTable(
                name: "SekaniRoots_EnglishWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnglishWordId = table.Column<int>(nullable: false),
                    SekaniRootId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniRoots_EnglishWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniRoots_EnglishWords_EnglishWords_EnglishWordId",
                        column: x => x.EnglishWordId,
                        principalTable: "EnglishWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SekaniRoots_EnglishWords_SekaniRoots_SekaniRootId",
                        column: x => x.SekaniRootId,
                        principalTable: "SekaniRoots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SekaniRoots_Topics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SekaniRootId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniRoots_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniRoots_Topics_SekaniRoots_SekaniRootId",
                        column: x => x.SekaniRootId,
                        principalTable: "SekaniRoots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SekaniRoots_Topics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SekaniRoots_EnglishWords_EnglishWordId",
                table: "SekaniRoots_EnglishWords",
                column: "EnglishWordId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniRoots_EnglishWords_SekaniRootId",
                table: "SekaniRoots_EnglishWords",
                column: "SekaniRootId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniRoots_Topics_SekaniRootId",
                table: "SekaniRoots_Topics",
                column: "SekaniRootId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniRoots_Topics_TopicId",
                table: "SekaniRoots_Topics",
                column: "TopicId");
        }
    }
}
