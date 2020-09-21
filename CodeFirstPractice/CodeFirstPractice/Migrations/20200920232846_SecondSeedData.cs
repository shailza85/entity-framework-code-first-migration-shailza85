using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstPractice.Migrations
{
    public partial class SecondSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShelfMaterial",
                columns: new[] { "id", "materialname" },
                values: new object[,]
                {
                    { 1, "metal" },
                    { 2, "wire" },
                    { 3, "wood" },
                    { 4, "plastic" },
                    { 5, "concrete" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShelfMaterial",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShelfMaterial",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShelfMaterial",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShelfMaterial",
                keyColumn: "id",
                keyValue: 5);

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

            migrationBuilder.DeleteData(
                table: "ShelfMaterial",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Shelves",
                columns: new[] { "id", "name", "shelfMaterial_id" },
                values: new object[,]
                {
                    { 5, "Games Shelf", 1 },
                    { 4, "Tools Shelf", 1 },
                    { 3, "Cloths Shelf", 1 },
                    { 2, "Books Shelf", 1 },
                    { 1, "Movies Shelf", 1 }
                });
        }
    }
}
