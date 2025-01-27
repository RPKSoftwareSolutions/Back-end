﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TKD.Infrastructure;

namespace TKD.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190518142629_FirstInit")]
    partial class FirstInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.ClientCorsOrigin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("Origin");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientCorsOrigins","auth");
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.ClientGrantType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("GrantType");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientGrantTypes","auth");
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.ClientScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("Scope");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientScopes","auth");
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.ClientSecret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("Expiration");

                    b.Property<string>("Type");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientSecrets","auth");
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(430);

                    b.Property<string>("ClientId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Data");

                    b.Property<DateTime?>("Expiration");

                    b.Property<string>("SubjectId");

                    b.Property<string>("Type");

                    b.HasKey("Key");

                    b.ToTable("PersistedGrants","auth");
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("EmailVerified");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberVerified");

                    b.Property<int?>("SekaniLevelId");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("SekaniLevelId");

                    b.ToTable("Users","auth");
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims","auth");
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.UserSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Browser");

                    b.Property<string>("DeviceId");

                    b.Property<string>("OperatingSystem");

                    b.Property<string>("RefreshToken");

                    b.Property<string>("SessionId");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSessions","auth");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.EnglishWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Standard");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("Word");

                    b.HasKey("Id");

                    b.ToTable("EnglishWords");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Image");

                    b.Property<string>("Notes");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("SekaniCategories");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Notes");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("SekaniForms");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Image");

                    b.Property<string>("Notes");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("SekaniLevels");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniRoot", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("IsNull");

                    b.Property<string>("RootWord");

                    b.Property<int>("SekaniCategoryId");

                    b.Property<int>("SekaniFormId");

                    b.Property<int>("SekaniLevelId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("SekaniCategoryId");

                    b.HasIndex("SekaniFormId");

                    b.HasIndex("SekaniLevelId");

                    b.ToTable("SekaniRoots");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniRootEnglishWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnglishWordId");

                    b.Property<int>("SekaniRootId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("EnglishWordId");

                    b.HasIndex("SekaniRootId");

                    b.ToTable("SekaniRootsEnglishWords");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniRootImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .IsRequired();

                    b.Property<string>("Format");

                    b.Property<string>("Notes");

                    b.Property<int>("SekaniRootId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("SekaniRootId");

                    b.ToTable("SekaniRootImages");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniRootTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SekaniRootId");

                    b.Property<int>("TopicId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("SekaniRootId");

                    b.HasIndex("TopicId");

                    b.ToTable("SekaniRootsTopics");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Phonetic");

                    b.Property<int>("SekaniRootId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("Word");

                    b.HasKey("Id");

                    b.HasIndex("SekaniRootId");

                    b.ToTable("SekaniWords");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniWordAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Key");

                    b.Property<int>("SekaniWordId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWordId");

                    b.ToTable("SekaniWordAttributes");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniWordAudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .IsRequired();

                    b.Property<string>("Format");

                    b.Property<string>("Notes");

                    b.Property<int>("SekaniWordId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWordId");

                    b.ToTable("SekaniWordAudios");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniWordExample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("English");

                    b.Property<string>("Sekani");

                    b.Property<int>("SekaniWordId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWordId");

                    b.ToTable("SekaniWordExamples");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniWordExampleAudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .IsRequired();

                    b.Property<string>("Format");

                    b.Property<string>("Notes");

                    b.Property<int>("SekaniWordExampleId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWordExampleId");

                    b.ToTable("SekaniWordExampleAudios");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Notes");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.UserActivityStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int>("UserId");

                    b.Property<string>("Value");

                    b.Property<string>("Variable");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserActivityStats");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.UserFailedWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SekaniWordId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWordId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFailedWords");
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.UserLearnedWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AnswerDateTime");

                    b.Property<int>("SekaniWordId");

                    b.Property<int>("TryCount");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWordId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLearnedWords");
                });

            modelBuilder.Entity("TKD.DomainModel.AuthenticateModels.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessTokenLifeTime");

                    b.Property<bool>("AllowOfflineAccess");

                    b.Property<string>("ClientId");

                    b.Property<bool>("Enabled");

                    b.Property<int>("RefreshTokenExpiration");

                    b.Property<int>("SlidingRefreshTokenLifetime");

                    b.HasKey("Id");

                    b.ToTable("Clients","auth");
                });

            modelBuilder.Entity("TKD.DomainModel.AuthenticateModels.EmailVerificationToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("ExpiryTime");

                    b.Property<string>("Token");

                    b.Property<bool>("Used");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailVerificationTokens","auth");
                });

            modelBuilder.Entity("TKD.DomainModel.AuthenticateModels.PasswordResetToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("ExpiryTime");

                    b.Property<string>("Token");

                    b.Property<bool>("Used");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordResetTokens","auth");
                });

            modelBuilder.Entity("TKD.DomainModel.AuthenticateModels.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Key");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.ClientCorsOrigin", b =>
                {
                    b.HasOne("TKD.DomainModel.AuthenticateModels.Client", "Client")
                        .WithMany("AllowedCorsOrigins")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.ClientGrantType", b =>
                {
                    b.HasOne("TKD.DomainModel.AuthenticateModels.Client", "Client")
                        .WithMany("AllowedGrantTypes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.ClientScope", b =>
                {
                    b.HasOne("TKD.DomainModel.AuthenticateModels.Client", "Client")
                        .WithMany("AllowedScopes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.ClientSecret", b =>
                {
                    b.HasOne("TKD.DomainModel.AuthenticateModels.Client", "Client")
                        .WithMany("ClientSecrets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.User", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.SekaniLevel")
                        .WithMany("Users")
                        .HasForeignKey("SekaniLevelId");
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.UserClaim", b =>
                {
                    b.HasOne("TKD.Domain.AuthenticateModels.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.AuthenticateModels.UserSession", b =>
                {
                    b.HasOne("TKD.Domain.AuthenticateModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniRoot", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.SekaniCategory", "SekaniCategory")
                        .WithMany("SekaniRoots")
                        .HasForeignKey("SekaniCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TKD.Domain.TKDModels.SekaniForm", "SekaniForm")
                        .WithMany("SekaniRoots")
                        .HasForeignKey("SekaniFormId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TKD.Domain.TKDModels.SekaniLevel", "SekaniLevel")
                        .WithMany("SekaniRoots")
                        .HasForeignKey("SekaniLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniRootEnglishWord", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.EnglishWord", "EnglishWord")
                        .WithMany("SekaniRootsEnglishWords")
                        .HasForeignKey("EnglishWordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TKD.Domain.TKDModels.SekaniRoot", "SekaniRoot")
                        .WithMany("SekaniRootsEnglishWords")
                        .HasForeignKey("SekaniRootId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniRootImage", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.SekaniRoot", "SekaniRoot")
                        .WithMany("SekaniRootImages")
                        .HasForeignKey("SekaniRootId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniRootTopic", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.SekaniRoot", "SekaniRoot")
                        .WithMany("SekaniRootsTopics")
                        .HasForeignKey("SekaniRootId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TKD.Domain.TKDModels.Topic", "Topic")
                        .WithMany("SekaniRootsTopics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniWord", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.SekaniRoot", "SekaniRoot")
                        .WithMany("SekaniWords")
                        .HasForeignKey("SekaniRootId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniWordAttribute", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.SekaniWord", "SekaniWord")
                        .WithMany("SekaniWordAttributes")
                        .HasForeignKey("SekaniWordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniWordAudio", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.SekaniWord", "SekaniWord")
                        .WithMany("SekaniWordAudios")
                        .HasForeignKey("SekaniWordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniWordExample", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.SekaniWord", "SekaniWord")
                        .WithMany("SekaniWordExamples")
                        .HasForeignKey("SekaniWordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.SekaniWordExampleAudio", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.SekaniWordExample", "SekaniWordExample")
                        .WithMany("SekaniWordExampleAudios")
                        .HasForeignKey("SekaniWordExampleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.UserActivityStat", b =>
                {
                    b.HasOne("TKD.Domain.AuthenticateModels.User", "User")
                        .WithMany("ActivityStats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.UserFailedWord", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.SekaniWord", "SekaniWord")
                        .WithMany("UsersFailed")
                        .HasForeignKey("SekaniWordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TKD.Domain.AuthenticateModels.User", "User")
                        .WithMany("UserFailedWords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.Domain.TKDModels.UserLearnedWord", b =>
                {
                    b.HasOne("TKD.Domain.TKDModels.SekaniWord", "SekaniWord")
                        .WithMany("UsersLearnt")
                        .HasForeignKey("SekaniWordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TKD.Domain.AuthenticateModels.User", "User")
                        .WithMany("UserLearnedWords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.DomainModel.AuthenticateModels.EmailVerificationToken", b =>
                {
                    b.HasOne("TKD.Domain.AuthenticateModels.User", "User")
                        .WithMany("EmailVerificationTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TKD.DomainModel.AuthenticateModels.PasswordResetToken", b =>
                {
                    b.HasOne("TKD.Domain.AuthenticateModels.User", "User")
                        .WithMany("PasswordResetTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
