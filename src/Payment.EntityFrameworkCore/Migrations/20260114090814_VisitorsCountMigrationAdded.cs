using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment.Migrations
{
    /// <inheritdoc />
    public partial class VisitorsCountMigrationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppVisitors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Identity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FirstVisitedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastVisitedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    VisitCount = table.Column<int>(type: "integer", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVisitors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppVisitors_Identity",
                table: "AppVisitors",
                column: "Identity",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppVisitors");
        }
    }
}
