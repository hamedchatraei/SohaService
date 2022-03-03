using Microsoft.EntityFrameworkCore.Migrations;

namespace SohaService.DataLayer.Migrations
{
    public partial class mig_UpdatePayWithRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepairId",
                table: "Pay",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pay_RepairId",
                table: "Pay",
                column: "RepairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pay_Repairs_RepairId",
                table: "Pay",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "RepairId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pay_Repairs_RepairId",
                table: "Pay");

            migrationBuilder.DropIndex(
                name: "IX_Pay_RepairId",
                table: "Pay");

            migrationBuilder.DropColumn(
                name: "RepairId",
                table: "Pay");
        }
    }
}
