using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuirkyCarRepair.DAL.Migrations
{
    public partial class NewTables_Vehicles_ServiceOrderStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "ServiceOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ServiceOrderStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceOrderId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrderStatuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceOrder_ServiceOrderStatus",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    PlateNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_VehicleId",
                table: "ServiceOrders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderStatuses_ServiceOrderId",
                table: "ServiceOrderStatuses",
                column: "ServiceOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrder_Vehicle",
                table: "ServiceOrders",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrder_Vehicle",
                table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "ServiceOrderStatuses");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_VehicleId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "ServiceOrders");
        }
    }
}
