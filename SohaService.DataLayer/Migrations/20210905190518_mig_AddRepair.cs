using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SohaService.DataLayer.Migrations
{
    public partial class mig_AddRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    RepairId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UnitStatusId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ReceivedUnitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedToSendUnitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendUnitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedAmount = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    DiscountTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCost = table.Column<int>(type: "int", nullable: false),
                    ReceivedAmount = table.Column<int>(type: "int", nullable: false),
                    RemainingAmount = table.Column<int>(type: "int", nullable: false),
                    DamageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoneDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRepair = table.Column<bool>(type: "bit", nullable: false),
                    IsReady = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.RepairId);
                    table.ForeignKey(
                        name: "FK_Repairs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repairs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repairs_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repairs_UnitStatus_UnitStatusId",
                        column: x => x.UnitStatusId,
                        principalTable: "UnitStatus",
                        principalColumn: "UnitStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_CompanyId",
                table: "Repairs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_CustomerId",
                table: "Repairs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_UnitId",
                table: "Repairs",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_UnitStatusId",
                table: "Repairs",
                column: "UnitStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repairs");
        }
    }
}
