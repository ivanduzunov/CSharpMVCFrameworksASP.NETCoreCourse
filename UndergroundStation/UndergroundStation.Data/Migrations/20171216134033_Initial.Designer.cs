﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using UndergroundStation.Data;
using UndergroundStation.Data.Models.Enums;

namespace UndergroundStation.Data.Migrations
{
    [DbContext(typeof(UndergroundStationDbContext))]
    [Migration("20171216134033_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("UndergroundStation.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<int?>("MotherCommentId");

                    b.Property<int?>("NewsArticleId");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MotherCommentId");

                    b.HasIndex("NewsArticleId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("UndergroundStation.Data.Models.ForumArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(3000);

                    b.Property<int?>("ForumThemeId");

                    b.Property<int?>("MotherArticleId");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ForumThemeId");

                    b.HasIndex("MotherArticleId");

                    b.ToTable("ForumArticles");
                });

            modelBuilder.Entity("UndergroundStation.Data.Models.ForumSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ForumSections");
                });

            modelBuilder.Entity("UndergroundStation.Data.Models.ForumTheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatorId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<int>("ForumSectionId");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ForumSectionId");

                    b.ToTable("ForumThemes");
                });

            modelBuilder.Entity("UndergroundStation.Data.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ForumArticleId");

                    b.Property<bool>("IsLiked");

                    b.Property<int?>("NewsArticleId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ForumArticleId");

                    b.HasIndex("NewsArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("UndergroundStation.Data.Models.NewsArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleType");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(6000);

                    b.Property<string>("ImageUrl");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("VideoUrl");

                    b.HasKey("Id");

                    b.ToTable("NewsArticles");
                });

            modelBuilder.Entity("UndergroundStation.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("UndergroundStation.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("UndergroundStation.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UndergroundStation.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("UndergroundStation.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UndergroundStation.Data.Models.Comment", b =>
                {
                    b.HasOne("UndergroundStation.Data.Models.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId");

                    b.HasOne("UndergroundStation.Data.Models.Comment", "MotherComment")
                        .WithMany("Answers")
                        .HasForeignKey("MotherCommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UndergroundStation.Data.Models.NewsArticle", "NewsArticle")
                        .WithMany("Comments")
                        .HasForeignKey("NewsArticleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("UndergroundStation.Data.Models.ForumArticle", b =>
                {
                    b.HasOne("UndergroundStation.Data.Models.User", "Author")
                        .WithMany("ForumArticles")
                        .HasForeignKey("AuthorId");

                    b.HasOne("UndergroundStation.Data.Models.ForumTheme", "ForumTheme")
                        .WithMany("Articles")
                        .HasForeignKey("ForumThemeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UndergroundStation.Data.Models.ForumArticle", "MotherArticle")
                        .WithMany("Answers")
                        .HasForeignKey("MotherArticleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("UndergroundStation.Data.Models.ForumTheme", b =>
                {
                    b.HasOne("UndergroundStation.Data.Models.User", "Creator")
                        .WithMany("ForumThemes")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UndergroundStation.Data.Models.ForumSection", "ForumSection")
                        .WithMany("Themes")
                        .HasForeignKey("ForumSectionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("UndergroundStation.Data.Models.Like", b =>
                {
                    b.HasOne("UndergroundStation.Data.Models.ForumArticle", "ForumArtcle")
                        .WithMany("Likes")
                        .HasForeignKey("ForumArticleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UndergroundStation.Data.Models.NewsArticle", "NewsArticle")
                        .WithMany("Likes")
                        .HasForeignKey("NewsArticleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UndergroundStation.Data.Models.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}