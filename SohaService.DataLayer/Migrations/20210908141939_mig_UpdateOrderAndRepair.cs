using Microsoft.EntityFrameworkCore.Migrations;

namespace SohaService.DataLayer.Migrations
{
    public partial class mig_UpdateOrderAndRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WitchOne",
                table: "Repairs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WitchOne",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WitchOne",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "WitchOne",
                table: "Orders");
        }
    }
}
