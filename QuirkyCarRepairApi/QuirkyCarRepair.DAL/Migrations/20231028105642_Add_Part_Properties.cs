using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuirkyCarRepair.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_Part_Properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "Parts",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Depth",
                table: "Parts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "Parts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Parts",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Parts",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Parts",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Parts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Width",
                table: "Parts",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Depth",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Parts");
        }
    }
}
