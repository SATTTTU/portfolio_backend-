using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment.Migrations
{
    /// <inheritdoc />
    public partial class WorkTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppWorkings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LeftAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsWorking = table.Column<bool>(type: "boolean", nullable: false),
                    WorkedAt = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppWorkings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingDescription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkingId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingDescription_AppWorkings_WorkingId",
                        column: x => x.WorkingId,
                        principalTable: "AppWorkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDescription_WorkingId",
                table: "WorkingDescription",
                column: "WorkingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkingDescription");

            migrationBuilder.DropTable(
                name: "AppWorkings");
        }
    }
}
