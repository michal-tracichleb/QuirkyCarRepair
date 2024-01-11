using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuirkyCarRepair.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NewTables_with_FixOldTables_spaghetti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Margin_Parts",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_MarginId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "MarginId",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Vehicles",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicles",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Vehicles",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TransactionStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ServiceOrderStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MarginId",
                table: "PartCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MainCategoriesServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarginId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategoriesServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Margin_MainCategoriesServices",
                        column: x => x.MarginId,
                        principalTable: "Margins",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderOwners",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    OperationalDocumentId = table.Column<int>(type: "int", nullable: true),
                    ServiceOrderId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOwners", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderOwners_OperationalDocuments_OperationalDocumentId",
                        column: x => x.OperationalDocumentId,
                        principalTable: "OperationalDocuments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OrderOwners_ServiceOrders_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_User_OrderOwners",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ServiceOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategoryServiceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOffers_MainCategoriesServices_MainCategoryServiceId",
                        column: x => x.MainCategoryServiceId,
                        principalTable: "MainCategoriesServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionStatuses_UserId",
                table: "TransactionStatuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderStatuses_UserId",
                table: "ServiceOrderStatuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCategories_MarginId",
                table: "PartCategories",
                column: "MarginId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCategoriesServices_MarginId",
                table: "MainCategoriesServices",
                column: "MarginId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOwners_OperationalDocumentId",
                table: "OrderOwners",
                column: "OperationalDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOwners_ServiceOrderId",
                table: "OrderOwners",
                column: "ServiceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOwners_UserId",
                table: "OrderOwners",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOffers_MainCategoryServiceId",
                table: "ServiceOffers",
                column: "MainCategoryServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Margin_PartCategories",
                table: "PartCategories",
                column: "MarginId",
                principalTable: "Margins",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ServiceOrderStatuses",
                table: "ServiceOrderStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_TransactionStatuses",
                table: "TransactionStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Vehicles",
                table: "Vehicles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Margin_PartCategories",
                table: "PartCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ServiceOrderStatuses",
                table: "ServiceOrderStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_User_TransactionStatuses",
                table: "TransactionStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "OrderOwners");

            migrationBuilder.DropTable(
                name: "ServiceOffers");

            migrationBuilder.DropTable(
                name: "MainCategoriesServices");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_TransactionStatuses_UserId",
                table: "TransactionStatuses");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrderStatuses_UserId",
                table: "ServiceOrderStatuses");

            migrationBuilder.DropIndex(
                name: "IX_PartCategories_MarginId",
                table: "PartCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TransactionStatuses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ServiceOrderStatuses");

            migrationBuilder.DropColumn(
                name: "MarginId",
                table: "PartCategories");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Vehicles",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicles",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Vehicles",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<int>(
                name: "MarginId",
                table: "Parts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_MarginId",
                table: "Parts",
                column: "MarginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Margin_Parts",
                table: "Parts",
                column: "MarginId",
                principalTable: "Margins",
                principalColumn: "ID");
        }
    }
}
