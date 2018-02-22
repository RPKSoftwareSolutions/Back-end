using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuthServer.Migrations
{
    public partial class revolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "SekaniWordTypes");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "SekaniWords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnglishWordId",
                table: "SekaniWords",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnglishWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Word = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SekaniWordAudios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(nullable: false),
                    Format = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SekaniWordId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniWordAudios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniWordAudios_SekaniWords_SekaniWordId",
                        column: x => x.SekaniWordId,
                        principalTable: "SekaniWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
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
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SekaniWordId = table.Column<int>(nullable: false),
                    Translationx = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_SekaniWords_SekaniWordId",
                        column: x => x.SekaniWordId,
                        principalTable: "SekaniWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslationExamples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    English = table.Column<string>(nullable: true),
                    Sekani = table.Column<string>(nullable: true),
                    TranslationId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationExamples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationExamples_Translations_TranslationId",
                        column: x => x.TranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslationPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(nullable: false),
                    Format = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    TranslationId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationPhotos_Translations_TranslationId",
                        column: x => x.TranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translations_Topics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TopicId = table.Column<int>(nullable: false),
                    TranslationId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Topics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translations_Topics_Translations_TranslationId",
                        column: x => x.TranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                    table.UniqueConstraint("unqIds", x => new { x.TopicId, x.TranslationId });
                });

            migrationBuilder.CreateTable(
                name: "TranslationExampleAudios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(nullable: false),
                    Format = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    TranslationExampleId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationExampleAudios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationExampleAudios_TranslationExamples_TranslationExampleId",
                        column: x => x.TranslationExampleId,
                        principalTable: "TranslationExamples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWords_CategoryId",
                table: "SekaniWords",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWords_EnglishWordId",
                table: "SekaniWords",
                column: "EnglishWordId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWordAudios_SekaniWordId",
                table: "SekaniWordAudios",
                column: "SekaniWordId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationExampleAudios_TranslationExampleId",
                table: "TranslationExampleAudios",
                column: "TranslationExampleId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationExamples_TranslationId",
                table: "TranslationExamples",
                column: "TranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationPhotos_TranslationId",
                table: "TranslationPhotos",
                column: "TranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_SekaniWordId",
                table: "Translations",
                column: "SekaniWordId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_Topics_TopicId",
                table: "Translations_Topics",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_Topics_TranslationId",
                table: "Translations_Topics",
                column: "TranslationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SekaniWords_Categories_CategoryId",
                table: "SekaniWords",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SekaniWords_EnglishWords_EnglishWordId",
                table: "SekaniWords",
                column: "EnglishWordId",
                principalTable: "EnglishWords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SekaniWords_Categories_CategoryId",
                table: "SekaniWords");

            migrationBuilder.DropForeignKey(
                name: "FK_SekaniWords_EnglishWords_EnglishWordId",
                table: "SekaniWords");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "EnglishWords");

            migrationBuilder.DropTable(
                name: "SekaniWordAudios");

            migrationBuilder.DropTable(
                name: "TranslationExampleAudios");

            migrationBuilder.DropTable(
                name: "TranslationPhotos");

            migrationBuilder.DropTable(
                name: "Translations_Topics");

            migrationBuilder.DropTable(
                name: "TranslationExamples");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_SekaniWords_CategoryId",
                table: "SekaniWords");

            migrationBuilder.DropIndex(
                name: "IX_SekaniWords_EnglishWordId",
                table: "SekaniWords");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "SekaniWords");

            migrationBuilder.DropColumn(
                name: "EnglishWordId",
                table: "SekaniWords");

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
        }
    }
}
