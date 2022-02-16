using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApi.Migrations
{
    public partial class SecondUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Cars",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Cars",
                newName: "ColorId");

            migrationBuilder.CreateTable(
                name: "CarColor",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarColor", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.TypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TypeId",
                table: "Cars",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarColor_ColorId",
                table: "Cars",
                column: "ColorId",
                principalTable: "CarColor",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarType_TypeId",
                table: "Cars",
                column: "TypeId",
                principalTable: "CarType",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarColor_ColorId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarType_TypeId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarColor");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ColorId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TypeId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Cars",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Cars",
                newName: "Color");
        }
    }
}
