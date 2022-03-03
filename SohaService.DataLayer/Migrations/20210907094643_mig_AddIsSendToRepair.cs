using Microsoft.EntityFrameworkCore.Migrations;

namespace SohaService.DataLayer.Migrations
{
    public partial class mig_AddIsSendToRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSend",
                table: "Repairs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSend",
                table: "Repairs");
        }
    }
}
