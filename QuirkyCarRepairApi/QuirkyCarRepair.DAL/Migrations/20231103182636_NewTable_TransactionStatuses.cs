using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuirkyCarRepair.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NewTable_TransactionStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    OperationalDocumentid = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionStatuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransactionStatus_OperationalDocument",
                        column: x => x.OperationalDocumentid,
                        principalTable: "OperationalDocuments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionStatus_User",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionStatuses_OperationalDocumentid",
                table: "TransactionStatuses",
                column: "OperationalDocumentid");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionStatuses_UserId",
                table: "TransactionStatuses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionStatuses");
        }
    }
}
