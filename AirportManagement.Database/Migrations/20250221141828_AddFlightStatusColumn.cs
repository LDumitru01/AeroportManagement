using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFlightStatusColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookedFlightsIds",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookedFlightsIds",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Flights");
        }
    }
}
