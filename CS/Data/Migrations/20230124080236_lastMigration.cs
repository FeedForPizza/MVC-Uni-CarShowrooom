using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS.Data.Migrations
{
    public partial class lastMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            

            //migrationBuilder.DropColumn(
            //    name: "CarsID",
            //    table: "carExtra");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "storage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "storage");

            migrationBuilder.AddColumn<int>(
                name: "CarsID",
                table: "carExtra",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_carExtra_CarsID",
                table: "carExtra",
                column: "CarsID");

            migrationBuilder.AddForeignKey(
                name: "FK_carExtra_cars_CarsID",
                table: "carExtra",
                column: "CarsID",
                principalTable: "cars",
                principalColumn: "CarsID");
        }
    }
}
