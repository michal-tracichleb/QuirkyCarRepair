using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuirkyCarRepair.DAL.Migrations
{
    public partial class NewTables_Margins_Parts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Margins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Margins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartCategoryId = table.Column<int>(type: "int", nullable: false),
                    MarginId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Margin_Parts",
                        column: x => x.MarginId,
                        principalTable: "Margins",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartCategory_Part",
                        column: x => x.PartCategoryId,
                        principalTable: "PartCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_MarginId",
                table: "Parts",
                column: "MarginId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartCategoryId",
                table: "Parts",
                column: "PartCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Margins");
        }
    }
}
