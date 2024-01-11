using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuirkyCarRepair.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderOwnerToServiceOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderOwners_ServiceOrders_ServiceOrderId",
                table: "OrderOwners");

            migrationBuilder.DropIndex(
                name: "IX_OrderOwners_ServiceOrderId",
                table: "OrderOwners");

            migrationBuilder.AddColumn<int>(
                name: "OrderOwnerId",
                table: "ServiceOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_OrderOwnerId",
                table: "ServiceOrders",
                column: "OrderOwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_OrderOwners_OrderOwnerId",
                table: "ServiceOrders",
                column: "OrderOwnerId",
                principalTable: "OrderOwners",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_OrderOwners_OrderOwnerId",
                table: "ServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_OrderOwnerId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "OrderOwnerId",
                table: "ServiceOrders");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOwners_ServiceOrderId",
                table: "OrderOwners",
                column: "ServiceOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderOwners_ServiceOrders_ServiceOrderId",
                table: "OrderOwners",
                column: "ServiceOrderId",
                principalTable: "ServiceOrders",
                principalColumn: "ID");
        }
    }
}
