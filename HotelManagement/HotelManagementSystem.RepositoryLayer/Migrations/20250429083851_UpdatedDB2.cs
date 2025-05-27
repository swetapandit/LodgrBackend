using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationGuests_Users_GuestId",
                table: "ReservationGuests");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationGuests_Guests_GuestId",
                table: "ReservationGuests",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationGuests_Guests_GuestId",
                table: "ReservationGuests");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationGuests_Users_GuestId",
                table: "ReservationGuests",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
