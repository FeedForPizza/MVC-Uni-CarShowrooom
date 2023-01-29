using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS.Data.Migrations
{
    public partial class AddExtras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "storage");

            migrationBuilder.CreateTable(
                name: "carExtra",
                columns: table => new
                {
                    ExtraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carExtra", x => x.ExtraID);
                    table.ForeignKey(
                        name: "FK_carExtra_cars_CarsID",
                        column: x => x.CarsID,
                        principalTable: "cars",
                        principalColumn: "CarsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carExtra_CarsID",
                table: "carExtra",
                column: "CarsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carExtra");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "storage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
