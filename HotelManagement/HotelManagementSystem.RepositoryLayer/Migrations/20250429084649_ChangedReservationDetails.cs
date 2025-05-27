using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class ChangedReservationDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationRooms",
                table: "ReservationRooms");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRooms_ReservationId",
                table: "ReservationRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationGuests",
                table: "ReservationGuests");

            migrationBuilder.DropIndex(
                name: "IX_ReservationGuests_ReservationId",
                table: "ReservationGuests");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReservationGuests");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "ReservationRooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "ReservationRooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "ReservationGuests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "ReservationGuests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationRooms",
                table: "ReservationRooms",
                columns: new[] { "ReservationId", "RoomId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationGuests",
                table: "ReservationGuests",
                columns: new[] { "ReservationId", "GuestId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationRooms",
                table: "ReservationRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationGuests",
                table: "ReservationGuests");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "ReservationRooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "ReservationRooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReservationRooms",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "ReservationGuests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "ReservationGuests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReservationGuests",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationRooms",
                table: "ReservationRooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationGuests",
                table: "ReservationGuests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRooms_ReservationId",
                table: "ReservationRooms",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationGuests_ReservationId",
                table: "ReservationGuests",
                column: "ReservationId");
        }
    }
}
