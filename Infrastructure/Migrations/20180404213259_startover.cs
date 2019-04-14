using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class startover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema("auth");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessTokenLifeTime = table.Column<int>(nullable: false),
                    AllowOfflineAccess = table.Column<bool>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    RefreshTokenExpiration = table.Column<int>(nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnglishWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Standard = table.Column<bool>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Word = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                schema: "auth",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength:450, nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true),
                    SubjectId = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

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
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
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
                name: "Users",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    EmailVerified = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberVerified = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientCorsOrigins",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    Origin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCorsOrigins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCorsOrigins_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalSchema: "auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientGrantTypes",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    GrantType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGrantTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientGrantTypes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalSchema: "auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientScopes",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    Scope = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientScopes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalSchema: "auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientSecrets",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientSecrets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalSchema: "auth",
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
                name: "EmailVerificationTokens",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ExpiryTime = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Used = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerificationTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailVerificationTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalSchema: "auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ExpiryTime = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Used = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalSchema: "auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalSchema: "auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Browser = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true),
                    OperatingSystem = table.Column<string>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: true),
                    SessionId = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalSchema: "auth",
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

            migrationBuilder.CreateTable(
                name: "SekaniWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Phonetic = table.Column<string>(nullable: true),
                    SekaniFormId = table.Column<int>(nullable: false),
                    SekaniRootId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Word = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SekaniWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SekaniWords_SekaniForms_SekaniFormId",
                        column: x => x.SekaniFormId,
                        principalTable: "SekaniForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SekaniWords_SekaniRoots_SekaniRootId",
                        column: x => x.SekaniRootId,
                        principalTable: "SekaniRoots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_ClientCorsOrigins_ClientId",
                table: "ClientCorsOrigins",
                schema: "auth",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGrantTypes_ClientId",
                table: "ClientGrantTypes",
                schema: "auth",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientScopes_ClientId",
                table: "ClientScopes",
                schema: "auth",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSecrets_ClientId",
                table: "ClientSecrets",
                schema: "auth",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerificationTokens_UserId",
                table: "EmailVerificationTokens",
                schema: "auth",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_UserId",
                table: "PasswordResetTokens",
                schema: "auth",
                column: "UserId");

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
                name: "IX_SekaniWordAudios_SekaniWordId",
                table: "SekaniWordAudios",
                column: "SekaniWordId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWordExampleAudios_SekaniWordExampleId",
                table: "SekaniWordExampleAudios",
                column: "SekaniWordExampleId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWordExamples_SekaniWordId",
                table: "SekaniWordExamples",
                column: "SekaniWordId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWords_SekaniFormId",
                table: "SekaniWords",
                column: "SekaniFormId");

            migrationBuilder.CreateIndex(
                name: "IX_SekaniWords_SekaniRootId",
                table: "SekaniWords",
                column: "SekaniRootId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                schema: "auth",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_UserId",
                table: "UserSessions",
                schema: "auth",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCorsOrigins", schema: "auth");

            migrationBuilder.DropTable(
                name: "ClientGrantTypes", schema: "auth");

            migrationBuilder.DropTable(
                name: "ClientScopes", schema: "auth");

            migrationBuilder.DropTable(
                name: "ClientSecrets", schema: "auth");

            migrationBuilder.DropTable(
                name: "EmailVerificationTokens", schema: "auth");

            migrationBuilder.DropTable(
                name: "PasswordResetTokens", schema: "auth");

            migrationBuilder.DropTable(
                name: "PersistedGrants", schema: "auth");

            migrationBuilder.DropTable(
                name: "SekaniRootImages");

            migrationBuilder.DropTable(
                name: "SekaniRoots_EnglishWords");

            migrationBuilder.DropTable(
                name: "SekaniRoots_Topics");

            migrationBuilder.DropTable(
                name: "SekaniWordAttributes");

            migrationBuilder.DropTable(
                name: "SekaniWordAudios");

            migrationBuilder.DropTable(
                name: "SekaniWordExampleAudios");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "UserClaims", schema: "auth");

            migrationBuilder.DropTable(
                name: "UserSessions", schema: "auth");

            migrationBuilder.DropTable(
                name: "Clients", schema: "auth");

            migrationBuilder.DropTable(
                name: "EnglishWords");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "SekaniWordExamples");

            migrationBuilder.DropTable(
                name: "Users", schema: "auth");

            migrationBuilder.DropTable(
                name: "SekaniWords");

            migrationBuilder.DropTable(
                name: "SekaniForms");

            migrationBuilder.DropTable(
                name: "SekaniRoots");

            migrationBuilder.DropTable(
                name: "SekaniCategories");

            migrationBuilder.DropTable(
                name: "SekaniLevels");
        }
    }
}
