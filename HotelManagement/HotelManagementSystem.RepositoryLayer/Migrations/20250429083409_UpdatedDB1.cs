using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationGuests_Reservations_ReservationId",
                table: "ReservationGuests");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationGuests_Reservations_ReservationId",
                table: "ReservationGuests",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationGuests_Reservations_ReservationId",
                table: "ReservationGuests");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationGuests_Reservations_ReservationId",
                table: "ReservationGuests",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
