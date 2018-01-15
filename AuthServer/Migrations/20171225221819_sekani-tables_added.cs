using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuthServer.Migrations
{
    public partial class sekanitables_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Notes = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SekaniWordTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Notes = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniWordTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SekaniWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LevelId = table.Column<int>(nullable: false),
                    Phonetic = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Word = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniWords_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SekaniWWTs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SekaniWordId = table.Column<int>(nullable: false),
                    SekaniWordTypeId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniWWTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniWWTs_SekaniWords_SekaniWordId",
                        column: x => x.SekaniWordId,
                        principalTable: "SekaniWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SekaniWWTs_SekaniWordTypes_SekaniWordTypeId",
                        column: x => x.SekaniWordTypeId,
                        principalTable: "SekaniWordTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SekaniPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    SekaniWwtId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniPhotos_SekaniWWTs_SekaniWwtId",
                        column: x => x.SekaniWwtId,
                        principalTable: "SekaniWWTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SekaniSound",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    SekaniWwtId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniSound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniSound_SekaniWWTs_SekaniWwtId",
                        column: x => x.SekaniWwtId,
                        principalTable: "SekaniWWTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslationsOfSekani",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Example1 = table.Column<string>(nullable: true),
                    Example2 = table.Column<string>(nullable: true),
                    Example3 = table.Column<string>(nullable: true),
                    SekaniWwtId = table.Column<int>(nullable: false),
                    Translation = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationsOfSekani", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationsOfSekani_SekaniWWTs_SekaniWwtId",
                        column: x => x.SekaniWwtId,
                        principalTable: "SekaniWWTs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SekaniPhotos_SekaniWwtId",
                table: "SekaniPhotos",
                column: "SekaniWwtId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniSound_SekaniWwtId",
                table: "SekaniSound",
                column: "SekaniWwtId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWords_LevelId",
                table: "SekaniWords",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWWTs_SekaniWordId",
                table: "SekaniWWTs",
                column: "SekaniWordId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWWTs_SekaniWordTypeId",
                table: "SekaniWWTs",
                column: "SekaniWordTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationsOfSekani_SekaniWwtId",
                table: "TranslationsOfSekani",
                column: "SekaniWwtId");

            string[] tmp = new string[2] { "SekaniWordId", "SekaniWordTypeId" };
            migrationBuilder.AddUniqueConstraint("SekaniWWTsUniqueCombination", "SekaniWWTs", tmp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SekaniPhotos");

            migrationBuilder.DropTable(
                name: "SekaniSound");

            migrationBuilder.DropTable(
                name: "TranslationsOfSekani");

            migrationBuilder.DropTable(
                name: "SekaniWWTs");

            migrationBuilder.DropTable(
                name: "SekaniWords");

            migrationBuilder.DropTable(
                name: "SekaniWordTypes");

            migrationBuilder.DropTable(
                name: "Levels");
        }
    }
}
