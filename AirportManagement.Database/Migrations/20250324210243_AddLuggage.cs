using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddLuggage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LuggageWeight",
                table: "Tickets",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LuggageWeight",
                table: "Tickets");
        }
    }
}
