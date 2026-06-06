using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace u23637707_HW01_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Event_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPricing = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Event_Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Event_Id", "Location", "TicketPricing", "Title" },
                values: new object[] { new Guid("b7f9e2a1-3c45-4d67-8f90-123456789abc"), "HB", 50.0, "SRC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
