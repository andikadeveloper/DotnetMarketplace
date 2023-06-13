using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetMarketplace.Migrations
{
    public partial class AddProductAndUserSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "https://images.tokopedia.net/img/cache/900/VqbcmM/2023/2/26/3a8909b4-fd5e-429d-a722-1695fbb28f1c.jpg", "Celana Panjang", 50000L },
                    { 2L, "https://images.tokopedia.net/img/cache/900/VqbcmM/2022/11/5/9fa4f2fb-d380-44aa-aa6a-b1c809b2bc27.jpg", "Kaos Oblong", 20000L },
                    { 3L, "https://images.tokopedia.net/img/cache/900/VqbcmM/2022/8/14/635bc911-24a0-46ec-a1dd-a0b3c193713a.jpg", "Topi Hitam", 10000L }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1L, "Andika", "Developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
