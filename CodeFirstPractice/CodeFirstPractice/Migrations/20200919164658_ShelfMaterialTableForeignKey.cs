using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstPractice.Migrations
{
    public partial class ShelfMaterialTableForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "shelfMaterial_id",
                table: "Shelves",
                type: "int(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShelfMaterial",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    materialname = table.Column<string>(type: "varchar(25)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfMaterial", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "id",
                keyValue: 1,
                column: "shelfMaterial_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "id",
                keyValue: 2,
                column: "shelfMaterial_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "id",
                keyValue: 3,
                column: "shelfMaterial_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "id",
                keyValue: 4,
                column: "shelfMaterial_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Shelves",
                keyColumn: "id",
                keyValue: 5,
                column: "shelfMaterial_id",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "FK_Shelves_ShelfMaterials",
                table: "Shelves",
                column: "shelfMaterial_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelves_ShelfMaterials",
                table: "Shelves",
                column: "shelfMaterial_id",
                principalTable: "ShelfMaterial",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelves_ShelfMaterials",
                table: "Shelves");

            migrationBuilder.DropTable(
                name: "ShelfMaterial");

            migrationBuilder.DropIndex(
                name: "FK_Shelves_ShelfMaterials",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "shelfMaterial_id",
                table: "Shelves");
        }
    }
}
