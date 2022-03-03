using Microsoft.EntityFrameworkCore.Migrations;

namespace SohaService.DataLayer.Migrations
{
    public partial class mig_UpdateOrderAndRepairWithFinalAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountTitle",
                table: "Repairs");

            migrationBuilder.RenameColumn(
                name: "DiscountTitle",
                table: "Orders",
                newName: "OrderAddress");

            migrationBuilder.AddColumn<int>(
                name: "FinalAmount",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DamageDescription",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinalAmount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalAmount",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "FinalAmount",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderAddress",
                table: "Orders",
                newName: "DiscountTitle");

            migrationBuilder.AddColumn<string>(
                name: "DiscountTitle",
                table: "Repairs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DamageDescription",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
