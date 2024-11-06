using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceData.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InvoiceItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "InvoiceItem");
        }
    }
}
