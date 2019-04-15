﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TKD.Infrastructure;

namespace  Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180601172313_activity_tracking_added")]
    partial class activity_tracking_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainModel.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessTokenLifeTime");

                    b.Property<bool>("AllowOfflineAccess");

                    b.Property<string>("ClientId");

                    b.Property<bool>("Enabled");

                    b.Property<int>("RefreshTokenExpiration");

                    b.Property<int>("SlidingRefreshTokenLifetime");

                    b.HasKey("Id");

                    b.ToTable("Clients","auth");
                });

            modelBuilder.Entity("DomainModel.ClientCorsOrigin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("Origin");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientCorsOrigins","auth");
                });

            modelBuilder.Entity("DomainModel.ClientGrantType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("GrantType");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientGrantTypes","auth");
                });

            modelBuilder.Entity("DomainModel.ClientScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("Scope");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientScopes","auth");
                });

            modelBuilder.Entity("DomainModel.ClientSecret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("Expiration");

                    b.Property<string>("Type");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientSecrets","auth");
                });

            modelBuilder.Entity("DomainModel.EmailVerificationToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("ExpiryTime");

                    b.Property<string>("Token");

                    b.Property<bool>("Used");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailVerificationTokens","auth");
                });

            modelBuilder.Entity("DomainModel.EnglishWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Standard");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("Word");

                    b.HasKey("Id");

                    b.ToTable("EnglishWords");
                });

            modelBuilder.Entity("DomainModel.PasswordResetToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("ExpiryTime");

                    b.Property<string>("Token");

                    b.Property<bool>("Used");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordResetTokens","auth");
                });

            modelBuilder.Entity("DomainModel.PersistedGrant", b =>
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

            modelBuilder.Entity("DomainModel.SekaniCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Notes");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("SekaniCategories");
                });

            modelBuilder.Entity("DomainModel.SekaniForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Notes");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("SekaniForms");
                });

            modelBuilder.Entity("DomainModel.SekaniLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Notes");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("SekaniLevels");
                });

            modelBuilder.Entity("DomainModel.SekaniRoot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("DomainModel.SekaniRoot_EnglishWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EnglishWordId");

                    b.Property<int>("SekaniRootId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("EnglishWordId");

                    b.HasIndex("SekaniRootId");

                    b.ToTable("SekaniRoots_EnglishWords");
                });

            modelBuilder.Entity("DomainModel.SekaniRoot_Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SekaniRootId");

                    b.Property<int>("TopicId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("SekaniRootId");

                    b.HasIndex("TopicId");

                    b.ToTable("SekaniRoots_Topics");
                });

            modelBuilder.Entity("DomainModel.SekaniRootImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("DomainModel.SekaniWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Phonetic");

                    b.Property<int>("SekaniRootId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("Word");

                    b.HasKey("Id");

                    b.HasIndex("SekaniRootId");

                    b.ToTable("SekaniWords");
                });

            modelBuilder.Entity("DomainModel.SekaniWordAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("SekaniWordId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWordId");

                    b.ToTable("SekaniWordAttributes");
                });

            modelBuilder.Entity("DomainModel.SekaniWordAudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("DomainModel.SekaniWordExample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("English");

                    b.Property<string>("Sekani");

                    b.Property<int>("SekaniWordId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWordId");

                    b.ToTable("SekaniWordExamples");
                });

            modelBuilder.Entity("DomainModel.SekaniWordExampleAudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("DomainModel.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Key");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("DomainModel.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Notes");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("DomainModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

                    b.Property<int>("SekaniLevelId");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("SekaniLevelId");

                    b.ToTable("Users","auth");
                });

            modelBuilder.Entity("DomainModel.UserActivityStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Activity1Life");

                    b.Property<int>("Activity2Life");

                    b.Property<int>("Score");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserActivityStats");
                });

            modelBuilder.Entity("DomainModel.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims","auth");
                });

            modelBuilder.Entity("DomainModel.UserFailedWords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SekaniWordId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWordId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFailedWords");
                });

            modelBuilder.Entity("DomainModel.UserLearntWords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SekaniWordId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWordId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLearntWords");
                });

            modelBuilder.Entity("DomainModel.UserSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("DomainModel.ClientCorsOrigin", b =>
                {
                    b.HasOne("DomainModel.Client", "Client")
                        .WithMany("AllowedCorsOrigins")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.ClientGrantType", b =>
                {
                    b.HasOne("DomainModel.Client", "Client")
                        .WithMany("AllowedGrantTypes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.ClientScope", b =>
                {
                    b.HasOne("DomainModel.Client", "Client")
                        .WithMany("AllowedScopes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.ClientSecret", b =>
                {
                    b.HasOne("DomainModel.Client", "Client")
                        .WithMany("ClientSecrets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.EmailVerificationToken", b =>
                {
                    b.HasOne("DomainModel.User", "User")
                        .WithMany("EmailVerificationTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.PasswordResetToken", b =>
                {
                    b.HasOne("DomainModel.User", "User")
                        .WithMany("PasswordResetTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniRoot", b =>
                {
                    b.HasOne("DomainModel.SekaniCategory", "SekaniCategory")
                        .WithMany("SekaniRoots")
                        .HasForeignKey("SekaniCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.SekaniForm", "SekaniForm")
                        .WithMany("SekaniRoots")
                        .HasForeignKey("SekaniFormId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.SekaniLevel", "SekaniLevel")
                        .WithMany("SekaniRoots")
                        .HasForeignKey("SekaniLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniRoot_EnglishWord", b =>
                {
                    b.HasOne("DomainModel.EnglishWord", "EnglishWord")
                        .WithMany("SekaniRoots_EnglishWords")
                        .HasForeignKey("EnglishWordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.SekaniRoot", "SekaniRoot")
                        .WithMany("SekaniRoots_EnglishWords")
                        .HasForeignKey("SekaniRootId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniRoot_Topic", b =>
                {
                    b.HasOne("DomainModel.SekaniRoot", "SekaniRoot")
                        .WithMany("SekaniRoots_Topics")
                        .HasForeignKey("SekaniRootId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.Topic", "Topic")
                        .WithMany("SekaniRoots_Topics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniRootImage", b =>
                {
                    b.HasOne("DomainModel.SekaniRoot", "SekaniRoot")
                        .WithMany("SekaniRootImages")
                        .HasForeignKey("SekaniRootId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniWord", b =>
                {
                    b.HasOne("DomainModel.SekaniRoot", "SekaniRoot")
                        .WithMany("SekaniWords")
                        .HasForeignKey("SekaniRootId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniWordAttribute", b =>
                {
                    b.HasOne("DomainModel.SekaniWord", "SekaniWord")
                        .WithMany("SekaniWordAttributes")
                        .HasForeignKey("SekaniWordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniWordAudio", b =>
                {
                    b.HasOne("DomainModel.SekaniWord", "SekaniWord")
                        .WithMany("SekaniWordAudios")
                        .HasForeignKey("SekaniWordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniWordExample", b =>
                {
                    b.HasOne("DomainModel.SekaniWord", "SekaniWord")
                        .WithMany("SekaniWordExamples")
                        .HasForeignKey("SekaniWordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniWordExampleAudio", b =>
                {
                    b.HasOne("DomainModel.SekaniWordExample", "SekaniWordExample")
                        .WithMany("SekaniWordExampleAudios")
                        .HasForeignKey("SekaniWordExampleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.User", b =>
                {
                    b.HasOne("DomainModel.SekaniLevel", "SekaniLevel")
                        .WithMany("Users")
                        .HasForeignKey("SekaniLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.UserActivityStat", b =>
                {
                    b.HasOne("DomainModel.User", "User")
                        .WithMany("ActivityStats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.UserClaim", b =>
                {
                    b.HasOne("DomainModel.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.UserFailedWords", b =>
                {
                    b.HasOne("DomainModel.SekaniWord", "SekaniWord")
                        .WithMany("UsersFailed")
                        .HasForeignKey("SekaniWordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.User", "User")
                        .WithMany("FailedWords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.UserLearntWords", b =>
                {
                    b.HasOne("DomainModel.SekaniWord", "SekaniWord")
                        .WithMany("UsersLearnt")
                        .HasForeignKey("SekaniWordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.User", "User")
                        .WithMany("LearntWords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.UserSession", b =>
                {
                    b.HasOne("DomainModel.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
