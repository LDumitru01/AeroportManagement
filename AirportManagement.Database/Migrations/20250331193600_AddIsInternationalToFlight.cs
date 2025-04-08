using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddIsInternationalToFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVip",
                table: "Passengers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInternational",
                table: "Flights",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVip",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "IsInternational",
                table: "Flights");
        }
    }
}
