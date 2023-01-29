using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS.Migrations
{
    public partial class ChangeCarModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    StorageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearOfManufacture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.StorageID);
                });

            migrationBuilder.CreateTable(
                name: "TestDrive",
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
                    table.PrimaryKey("PK_TestDrive", x => x.TestDriveID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
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
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Storage_StorageID",
                        column: x => x.StorageID,
                        principalTable: "Storage",
                        principalColumn: "StorageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
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
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Cars", x => x.CarsID);
                    table.ForeignKey(
                        name: "FK_Cars_Orders_ordersOrderID",
                        column: x => x.ordersOrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Storage_StorageID",
                        column: x => x.StorageID,
                        principalTable: "Storage",
                        principalColumn: "StorageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_TestDrive_TestDriveID",
                        column: x => x.TestDriveID,
                        principalTable: "TestDrive",
                        principalColumn: "TestDriveID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarExtra",
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
                    table.PrimaryKey("PK_CarExtra", x => x.ExtraID);
                    table.ForeignKey(
                        name: "FK_CarExtra_Cars_CarsID",
                        column: x => x.CarsID,
                        principalTable: "Cars",
                        principalColumn: "CarsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarExtra_CarsID",
                table: "CarExtra",
                column: "CarsID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ordersOrderID",
                table: "Cars",
                column: "ordersOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_StorageID",
                table: "Cars",
                column: "StorageID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TestDriveID",
                table: "Cars",
                column: "TestDriveID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StorageID",
                table: "Orders",
                column: "StorageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarExtra");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "TestDrive");

            migrationBuilder.DropTable(
                name: "Storage");
        }
    }
}
