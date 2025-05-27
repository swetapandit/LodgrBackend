using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CreatedBy",
                table: "Reservations",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_CreatedBy",
                table: "Reservations",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_CreatedBy",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CreatedBy",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Reservations");
        }
    }
}
