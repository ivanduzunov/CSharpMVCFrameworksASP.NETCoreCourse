using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UndergroundStation.Data.Migrations
{
    public partial class TablesCompleteInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Style = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForumThemes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumThemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(maxLength: 4000, nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    PublishedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    VideoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicVideos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtistId = table.Column<int>(nullable: false),
                    Style = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicVideos_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<string>(nullable: true),
                    Content = table.Column<string>(maxLength: 3000, nullable: false),
                    ForumThemeId = table.Column<int>(nullable: false),
                    MotherArticleId = table.Column<int>(nullable: true),
                    PublishedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumArticles_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumArticles_ForumThemes_ForumThemeId",
                        column: x => x.ForumThemeId,
                        principalTable: "ForumThemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumArticles_ForumArticles_MotherArticleId",
                        column: x => x.MotherArticleId,
                        principalTable: "ForumArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNewsArticleLikes",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNewsArticleLikes", x => new { x.UserId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_UserNewsArticleLikes_NewsArticles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "NewsArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNewsArticleLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNewsArticleUnlikes",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNewsArticleUnlikes", x => new { x.UserId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_UserNewsArticleUnlikes_NewsArticles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "NewsArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNewsArticleUnlikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerCommentId = table.Column<int>(nullable: true),
                    ArtistId = table.Column<int>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true),
                    Content = table.Column<string>(maxLength: 1000, nullable: false),
                    MusicVideoId = table.Column<int>(nullable: true),
                    PublishedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_AnswerCommentId",
                        column: x => x.AnswerCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_MusicVideos_MusicVideoId",
                        column: x => x.MusicVideoId,
                        principalTable: "MusicVideos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnswerCommentId",
                table: "Comments",
                column: "AnswerCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArtistId",
                table: "Comments",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MusicVideoId",
                table: "Comments",
                column: "MusicVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumArticles_AuthorId",
                table: "ForumArticles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumArticles_ForumThemeId",
                table: "ForumArticles",
                column: "ForumThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumArticles_MotherArticleId",
                table: "ForumArticles",
                column: "MotherArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicVideos_ArtistId",
                table: "MusicVideos",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNewsArticleLikes_ArticleId",
                table: "UserNewsArticleLikes",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNewsArticleUnlikes_ArticleId",
                table: "UserNewsArticleUnlikes",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ForumArticles");

            migrationBuilder.DropTable(
                name: "UserNewsArticleLikes");

            migrationBuilder.DropTable(
                name: "UserNewsArticleUnlikes");

            migrationBuilder.DropTable(
                name: "MusicVideos");

            migrationBuilder.DropTable(
                name: "ForumThemes");

            migrationBuilder.DropTable(
                name: "NewsArticles");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
