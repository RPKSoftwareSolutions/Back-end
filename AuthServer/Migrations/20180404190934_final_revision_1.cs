using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuthServer.Migrations
{
    public partial class final_revision_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SekaniWords_Categories_CategoryId",
                table: "SekaniWords");

            migrationBuilder.DropForeignKey(
                name: "FK_SekaniWords_EnglishWords_EnglishWordId",
                table: "SekaniWords");

            migrationBuilder.DropForeignKey(
                name: "FK_SekaniWords_Levels_LevelId",
                table: "SekaniWords");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "TranslationExampleAudios");

            migrationBuilder.DropTable(
                name: "TranslationPhotos");

            migrationBuilder.DropTable(
                name: "Translations_Topics");

            migrationBuilder.DropTable(
                name: "TranslationExamples");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_SekaniWords_EnglishWordId",
                table: "SekaniWords");

            migrationBuilder.DropColumn(
                name: "EnglishWordId",
                table: "SekaniWords");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "SekaniWords",
                newName: "SekaniRootId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "SekaniWords",
                newName: "SekaniFormId");

            migrationBuilder.RenameIndex(
                name: "IX_SekaniWords_LevelId",
                table: "SekaniWords",
                newName: "IX_SekaniWords_SekaniRootId");

            migrationBuilder.RenameIndex(
                name: "IX_SekaniWords_CategoryId",
                table: "SekaniWords",
                newName: "IX_SekaniWords_SekaniFormId");

            migrationBuilder.AddColumn<bool>(
                name: "Standard",
                table: "EnglishWords",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SekaniCategories",
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
                    table.PrimaryKey("PK_SekaniCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SekaniForms",
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
                    table.PrimaryKey("PK_SekaniForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SekaniLevels",
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
                    table.PrimaryKey("PK_SekaniLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SekaniWordAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    SekaniWordId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniWordAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniWordAttributes_SekaniWords_SekaniWordId",
                        column: x => x.SekaniWordId,
                        principalTable: "SekaniWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SekaniWordExamples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    English = table.Column<string>(nullable: true),
                    Sekani = table.Column<string>(nullable: true),
                    SekaniWordId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniWordExamples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniWordExamples_SekaniWords_SekaniWordId",
                        column: x => x.SekaniWordId,
                        principalTable: "SekaniWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SekaniRoots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsNull = table.Column<bool>(nullable: false),
                    RootWord = table.Column<string>(nullable: true),
                    SekaniCategoryId = table.Column<int>(nullable: false),
                    SekaniLevelId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniRoots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniRoots_SekaniCategories_SekaniCategoryId",
                        column: x => x.SekaniCategoryId,
                        principalTable: "SekaniCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SekaniRoots_SekaniLevels_SekaniLevelId",
                        column: x => x.SekaniLevelId,
                        principalTable: "SekaniLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SekaniWordExampleAudios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(nullable: false),
                    Format = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SekaniWordExampleId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniWordExampleAudios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniWordExampleAudios_SekaniWordExamples_SekaniWordExampleId",
                        column: x => x.SekaniWordExampleId,
                        principalTable: "SekaniWordExamples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SekaniRootImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(nullable: false),
                    Format = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SekaniRootId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniRootImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniRootImages_SekaniRoots_SekaniRootId",
                        column: x => x.SekaniRootId,
                        principalTable: "SekaniRoots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_SekaniRootImages_SekaniRootId",
                table: "SekaniRootImages",
                column: "SekaniRootId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniRoots_SekaniCategoryId",
                table: "SekaniRoots",
                column: "SekaniCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniRoots_SekaniLevelId",
                table: "SekaniRoots",
                column: "SekaniLevelId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWordAttributes_SekaniWordId",
                table: "SekaniWordAttributes",
                column: "SekaniWordId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWordExampleAudios_SekaniWordExampleId",
                table: "SekaniWordExampleAudios",
                column: "SekaniWordExampleId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWordExamples_SekaniWordId",
                table: "SekaniWordExamples",
                column: "SekaniWordId");

            migrationBuilder.AddForeignKey(
                name: "FK_SekaniWords_SekaniForms_SekaniFormId",
                table: "SekaniWords",
                column: "SekaniFormId",
                principalTable: "SekaniForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SekaniWords_SekaniRoots_SekaniRootId",
                table: "SekaniWords",
                column: "SekaniRootId",
                principalTable: "SekaniRoots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SekaniWords_SekaniForms_SekaniFormId",
                table: "SekaniWords");

            migrationBuilder.DropForeignKey(
                name: "FK_SekaniWords_SekaniRoots_SekaniRootId",
                table: "SekaniWords");

            migrationBuilder.DropTable(
                name: "SekaniForms");

            migrationBuilder.DropTable(
                name: "SekaniRootImages");

            migrationBuilder.DropTable(
                name: "SekaniRoots_EnglishWords");

            migrationBuilder.DropTable(
                name: "SekaniRoots_Topics");

            migrationBuilder.DropTable(
                name: "SekaniWordAttributes");

            migrationBuilder.DropTable(
                name: "SekaniWordExampleAudios");

            migrationBuilder.DropTable(
                name: "SekaniRoots");

            migrationBuilder.DropTable(
                name: "SekaniWordExamples");

            migrationBuilder.DropTable(
                name: "SekaniCategories");

            migrationBuilder.DropTable(
                name: "SekaniLevels");

            migrationBuilder.DropColumn(
                name: "Standard",
                table: "EnglishWords");

            migrationBuilder.RenameColumn(
                name: "SekaniRootId",
                table: "SekaniWords",
                newName: "LevelId");

            migrationBuilder.RenameColumn(
                name: "SekaniFormId",
                table: "SekaniWords",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SekaniWords_SekaniRootId",
                table: "SekaniWords",
                newName: "IX_SekaniWords_LevelId");

            migrationBuilder.RenameIndex(
                name: "IX_SekaniWords_SekaniFormId",
                table: "SekaniWords",
                newName: "IX_SekaniWords_CategoryId");

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
                name: "IX_SekaniWords_EnglishWordId",
                table: "SekaniWords",
                column: "EnglishWordId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SekaniWords_Levels_LevelId",
                table: "SekaniWords",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
