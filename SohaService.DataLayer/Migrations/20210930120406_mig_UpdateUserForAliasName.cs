using Microsoft.EntityFrameworkCore.Migrations;

namespace SohaService.DataLayer.Migrations
{
    public partial class mig_UpdateUserForAliasName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAliasName",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedServiceAmount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstimatedUnitAmount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAliasName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EstimatedServiceAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EstimatedUnitAmount",
                table: "Orders");
        }
    }
}
