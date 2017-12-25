﻿// <auto-generated />
using AuthServer.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AuthServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20171224204643_sekani-tables_added")]
    partial class sekanitables_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("EmailVerificationTokens");
                });

            modelBuilder.Entity("DomainModel.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Notes");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Levels");
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

                    b.ToTable("PasswordResetTokens");
                });

            modelBuilder.Entity("DomainModel.SekaniPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<int>("SekaniWwtId");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWwtId");

                    b.ToTable("SekaniPhotos");
                });

            modelBuilder.Entity("DomainModel.SekaniSound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<int>("SekaniWwtId");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWwtId");

                    b.ToTable("SekaniSound");
                });

            modelBuilder.Entity("DomainModel.SekaniWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<int>("LevelId");

                    b.Property<string>("Phonetic");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("Word");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.ToTable("SekaniWords");
                });

            modelBuilder.Entity("DomainModel.SekaniWordType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Notes");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("SekaniWordTypes");
                });

            modelBuilder.Entity("DomainModel.SekaniWWT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SekaniWordId");

                    b.Property<int>("SekaniWordTypeId");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWordId");

                    b.HasIndex("SekaniWordTypeId");

                    b.ToTable("SekaniWWTs");
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

            modelBuilder.Entity("DomainModel.TranslationOfSekani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Example1");

                    b.Property<string>("Example2");

                    b.Property<string>("Example3");

                    b.Property<int>("SekaniWwtId");

                    b.Property<string>("Translation");

                    b.HasKey("Id");

                    b.HasIndex("SekaniWwtId");

                    b.ToTable("TranslationsOfSekani");
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

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
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

                    b.ToTable("UserClaims");
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

            modelBuilder.Entity("DomainModel.SekaniPhoto", b =>
                {
                    b.HasOne("DomainModel.SekaniWWT", "SekaniWWT")
                        .WithMany("SekaniPhotos")
                        .HasForeignKey("SekaniWwtId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniSound", b =>
                {
                    b.HasOne("DomainModel.SekaniWWT", "SekaniWWT")
                        .WithMany("SekaniSounds")
                        .HasForeignKey("SekaniWwtId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniWord", b =>
                {
                    b.HasOne("DomainModel.Level", "Level")
                        .WithMany("SekaniWords")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.SekaniWWT", b =>
                {
                    b.HasOne("DomainModel.SekaniWord", "SekaniWord")
                        .WithMany("SekaniWWTs")
                        .HasForeignKey("SekaniWordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModel.SekaniWordType", "SekaniWordType")
                        .WithMany("SekaniWWTs")
                        .HasForeignKey("SekaniWordTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.TranslationOfSekani", b =>
                {
                    b.HasOne("DomainModel.SekaniWWT", "SekaniWWT")
                        .WithMany("TranslationsOfSekani")
                        .HasForeignKey("SekaniWwtId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.UserClaim", b =>
                {
                    b.HasOne("DomainModel.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
