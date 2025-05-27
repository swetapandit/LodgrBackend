using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedGuests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Reservations_ReservationId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Rooms_RoomId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_CreatedBy",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CreatedBy",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Guests_ReservationId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_RoomId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Reservations",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                newName: "IX_Reservations_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservations",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                newName: "IX_Reservations_RoomId");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CreatedBy",
                table: "Reservations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_ReservationId",
                table: "Guests",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_RoomId",
                table: "Guests",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Reservations_ReservationId",
                table: "Guests",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Rooms_RoomId",
                table: "Guests",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_CreatedBy",
                table: "Reservations",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
