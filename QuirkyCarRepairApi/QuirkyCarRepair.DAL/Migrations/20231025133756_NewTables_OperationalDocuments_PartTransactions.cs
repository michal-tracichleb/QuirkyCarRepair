using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuirkyCarRepair.DAL.Migrations
{
    public partial class NewTables_OperationalDocuments_PartTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationalDocuments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceOrderId = table.Column<int>(type: "int", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationalDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceOrder_OperationalDocument",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PartTransactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    OperationalDocumentId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarginValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartTransactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OperationalDocument_PartTransaction",
                        column: x => x.OperationalDocumentId,
                        principalTable: "OperationalDocuments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Part_PartTransaction",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationalDocuments_ServiceOrderId",
                table: "OperationalDocuments",
                column: "ServiceOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PartTransactions_OperationalDocumentId",
                table: "PartTransactions",
                column: "OperationalDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PartTransactions_PartId",
                table: "PartTransactions",
                column: "PartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartTransactions");

            migrationBuilder.DropTable(
                name: "OperationalDocuments");
        }
    }
}
