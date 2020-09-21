using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstPractice.Migrations
{
    public partial class FirstSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shelves",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Movies Shelf" },
                    { 2, "Books Shelf" },
                    { 3, "Cloths Shelf" },
                    { 4, "Tools Shelf" },
                    { 5, "Games Shelf" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
