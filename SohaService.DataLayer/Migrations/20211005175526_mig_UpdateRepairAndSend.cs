using Microsoft.EntityFrameworkCore.Migrations;

namespace SohaService.DataLayer.Migrations
{
    public partial class mig_UpdateRepairAndSend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Units_UnitId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_UnitId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Repairs");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SendToCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnitName",
                table: "Repairs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SendToCompanies");

            migrationBuilder.DropColumn(
                name: "UnitName",
                table: "Repairs");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_UnitId",
                table: "Repairs",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Units_UnitId",
                table: "Repairs",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
