using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetMarketplace.Migrations
{
    public partial class AddPaymentProviderAndShippingProviderOnTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentProvider",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingProvider",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentProvider",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ShippingProvider",
                table: "Transactions");
        }
    }
}
