using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS.Data.Migrations
{
    public partial class ModelsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "storage",
                columns: table => new
                {
                    StorageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearOfManufacture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storage", x => x.StorageID);
                });

            migrationBuilder.CreateTable(
                name: "testDrive",
                columns: table => new
                {
                    TestDriveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOTestDrive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfQuery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testDrive", x => x.TestDriveID);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Extra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceWithExtras = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SumOfOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ClientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_orders_storage_StorageID",
                        column: x => x.StorageID,
                        principalTable: "storage",
                        principalColumn: "StorageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    CarsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    MaxSpeed = table.Column<int>(type: "int", nullable: false),
                    MinSpeed = table.Column<int>(type: "int", nullable: false),
                    TypeFuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    TypeEngine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageExpenseTOWN = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageExpenseONROAD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageExpenseCOMBINED = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearOfManufacture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Doors = table.Column<int>(type: "int", nullable: false),
                    TypeCompartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ordersOrderID = table.Column<int>(type: "int", nullable: false),
                    StorageID = table.Column<int>(type: "int", nullable: false),
                    TestDriveID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.CarsID);
                    table.ForeignKey(
                        name: "FK_cars_orders_ordersOrderID",
                        column: x => x.ordersOrderID,
                        principalTable: "orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cars_storage_StorageID",
                        column: x => x.StorageID,
                        principalTable: "storage",
                        principalColumn: "StorageID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_cars_testDrive_TestDriveID",
                        column: x => x.TestDriveID,
                        principalTable: "testDrive",
                        principalColumn: "TestDriveID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_ordersOrderID",
                table: "cars",
                column: "ordersOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_cars_StorageID",
                table: "cars",
                column: "StorageID");

            migrationBuilder.CreateIndex(
                name: "IX_cars_TestDriveID",
                table: "cars",
                column: "TestDriveID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_StorageID",
                table: "orders",
                column: "StorageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "testDrive");

            migrationBuilder.DropTable(
                name: "storage");
        }
    }
}
