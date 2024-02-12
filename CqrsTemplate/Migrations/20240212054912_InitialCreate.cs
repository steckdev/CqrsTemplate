using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CqrsTemplate.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GivenName = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    BirthLocation = table.Column<string>(type: "TEXT", nullable: true),
                    DeathDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    DeathLocation = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "idx_users_birthdate",
                table: "Users",
                column: "BirthDate"
            );
            migrationBuilder.CreateIndex(
                name: "idx_users_deathdate",
                table: "Users",
                column: "DeathDate"
            );
            migrationBuilder.CreateIndex(
                name: "idx_users_createdhdate",
                table: "Users",
                column: "CreatedDate"
            );
            migrationBuilder.CreateIndex(
                name: "idx_users_lastmodifiedhdate",
                table: "Users",
                column: "LastModifiedDate"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
