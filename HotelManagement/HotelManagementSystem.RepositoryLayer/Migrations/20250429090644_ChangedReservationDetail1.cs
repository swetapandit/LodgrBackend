using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class ChangedReservationDetail1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationGuests_Reservations_ReservationId1",
                table: "ReservationGuests");

            migrationBuilder.DropIndex(
                name: "IX_ReservationGuests_ReservationId1",
                table: "ReservationGuests");

            migrationBuilder.DropColumn(
                name: "ReservationId1",
                table: "ReservationGuests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId1",
                table: "ReservationGuests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationGuests_ReservationId1",
                table: "ReservationGuests",
                column: "ReservationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationGuests_Reservations_ReservationId1",
                table: "ReservationGuests",
                column: "ReservationId1",
                principalTable: "Reservations",
                principalColumn: "ReservationId");
        }
    }
}
