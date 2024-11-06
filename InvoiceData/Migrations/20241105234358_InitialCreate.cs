using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateIssued = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillTo_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillTo_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillTo_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillTo_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillTo_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillTo_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillTo_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmountDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceNumber);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    Description = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => new { x.InvoiceId, x.Description, x.Amount });
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceNumber",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
