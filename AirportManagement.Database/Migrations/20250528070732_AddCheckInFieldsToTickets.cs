using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckInFieldsToTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckInType",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedIn",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckInType",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IsCheckedIn",
                table: "Tickets");
        }
    }
}
