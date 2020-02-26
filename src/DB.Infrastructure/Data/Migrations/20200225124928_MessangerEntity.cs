using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Infrastructure.Data.Migrations
{
    public partial class MessangerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyEntityId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messangers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: false),
                    Token = table.Column<string>(maxLength: 250, nullable: false),
                    Type = table.Column<short>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messangers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messangers_CompanyEntity_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messangers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyEntityId",
                table: "Users",
                column: "CompanyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Messangers_CompanyId",
                table: "Messangers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Messangers_UserId",
                table: "Messangers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CompanyEntity_CompanyEntityId",
                table: "Users",
                column: "CompanyEntityId",
                principalTable: "CompanyEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CompanyEntity_CompanyEntityId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Messangers");

            migrationBuilder.DropTable(
                name: "CompanyEntity");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyEntityId",
                table: "Users");
        }
    }
}
