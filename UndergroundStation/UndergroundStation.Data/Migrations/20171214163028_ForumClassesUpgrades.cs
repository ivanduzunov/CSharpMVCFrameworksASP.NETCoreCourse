using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UndergroundStation.Data.Migrations
{
    public partial class ForumClassesUpgrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "ForumThemes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForumSectionId",
                table: "ForumThemes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ForumSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    Tittle = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumSections", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumThemes_CreatorId",
                table: "ForumThemes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThemes_ForumSectionId",
                table: "ForumThemes",
                column: "ForumSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThemes_AspNetUsers_CreatorId",
                table: "ForumThemes",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThemes_ForumSections_ForumSectionId",
                table: "ForumThemes",
                column: "ForumSectionId",
                principalTable: "ForumSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumThemes_AspNetUsers_CreatorId",
                table: "ForumThemes");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThemes_ForumSections_ForumSectionId",
                table: "ForumThemes");

            migrationBuilder.DropTable(
                name: "ForumSections");

            migrationBuilder.DropIndex(
                name: "IX_ForumThemes_CreatorId",
                table: "ForumThemes");

            migrationBuilder.DropIndex(
                name: "IX_ForumThemes_ForumSectionId",
                table: "ForumThemes");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ForumThemes");

            migrationBuilder.DropColumn(
                name: "ForumSectionId",
                table: "ForumThemes");
        }
    }
}
