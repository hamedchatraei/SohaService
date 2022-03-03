using Microsoft.EntityFrameworkCore.Migrations;

namespace SohaService.DataLayer.Migrations
{
    public partial class mig_AddConfirmationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfirmationStatusId",
                table: "Repairs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RepairId",
                table: "Pay",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Pay",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConfirmationStatusId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConfirmationStatus",
                columns: table => new
                {
                    ConfirmationStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfirmationStatusTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmationStatus", x => x.ConfirmationStatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ConfirmationStatusId",
                table: "Repairs",
                column: "ConfirmationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ConfirmationStatusId",
                table: "Orders",
                column: "ConfirmationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ConfirmationStatus_ConfirmationStatusId",
                table: "Orders",
                column: "ConfirmationStatusId",
                principalTable: "ConfirmationStatus",
                principalColumn: "ConfirmationStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_ConfirmationStatus_ConfirmationStatusId",
                table: "Repairs",
                column: "ConfirmationStatusId",
                principalTable: "ConfirmationStatus",
                principalColumn: "ConfirmationStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ConfirmationStatus_ConfirmationStatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_ConfirmationStatus_ConfirmationStatusId",
                table: "Repairs");

            migrationBuilder.DropTable(
                name: "ConfirmationStatus");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_ConfirmationStatusId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ConfirmationStatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ConfirmationStatusId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "ConfirmationStatusId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "RepairId",
                table: "Pay",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Pay",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
